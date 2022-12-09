using ChatAppServer.DTO;
using ChatAppServer.Model;
using ChatAppServer.ServerSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatAppServer.Controller
{
    public class GroupController
    {
        private readonly Context _context;
        public GroupController()
        {
            _context = new Context();
        }
        public async Task<bool> GroupHandler(Base json, List<Worker> workers, Worker from)
        {
            switch (json.action.ToLower())
            {
                case "create":
                    {
                        var model = new ChatGroup().GetFromJson(json.content);
                        var response = new response { action = "create", content = Create(model).Result };
                        from.Send(response.ParseToJson());
                        return true;
                    }
                    break;
                case "addmember":
                    {
                        var model = new AddMember().GetFromJson(json.content);
                        var response = new response { action = "addmember", content = AddMem(model).Result };
                        from.Send(response.ParseToJson());
                        return true;
                    }
                    break;
                case "getall":
                    {
                        var model = new GetGroupByUser().GetFromJson(json.content);
                        var response = new response { action = "getall", content = GetByUser(model).Result };
                        from.Send(response.ParseToJson());
                        return true;
                    }
                    break;
                default: return false;
            }
            return false;
        }
        private async Task<string> Create(ChatGroup model)
        {
            try
            {
                if (!_context.ChatGroups.Any(x => x.GroupName == model.GroupName))
                {
                    _context.ChatGroups.Add(model);
                    await _context.SaveChangesAsync();
                    return "Create group complete!";
                }
                else return "Conflict";
            } catch (Exception ex)
            {
                return "Some thing went wrong, please contact your admin";
            }
        }
        private async Task<string> AddMem(AddMember model)
        {
            try
            {
                if (!_context.ChatGroups.Any(x=>x.GroupId == model.GroupId))
                {
                    var gr = new ChatGroup { GroupId = Guid.NewGuid(), CreatedDate = DateTime.Now, GroupName = "Group" };
                    model.GroupId = gr.GroupId;
                    _context.ChatGroups.Add(gr);
                    foreach (var item in model.user)
                    {
                        _context.GroupUsers.Add(new GroupUser { GroupId = model.GroupId, UserId = item.UserId, isApprove = true});
                    }
                    
                } else
                {
                    if (_context.GroupUsers.Where(x=>x.GroupId==model.GroupId).ToList().Count == 2)
                    {
                        var gr = new ChatGroup { GroupId = Guid.NewGuid(), CreatedDate = DateTime.Now, GroupName = "Group" };
                        model.GroupId = gr.GroupId;
                        _context.ChatGroups.Add(gr);
                        foreach (var item in model.user)
                        {
                            _context.GroupUsers.Add(new GroupUser { GroupId = model.GroupId, UserId = item.UserId, isApprove = true });
                        }
                    }
                    else
                    {
                        foreach(var item in model.user)
                        {
                            _context.GroupUsers.Add(item);
                        }
                    }
                }
                await _context.SaveChangesAsync();
                return model.GroupId.ToString();
            } catch(Exception ex)
            {
                return "Add member fail!";
            }
        }
        private async Task<string> GetByUser(GetGroupByUser model)
        {
            try
            {
                var list = _context.GroupUsers.Where(x => x.UserId == model.userID).ToList();
                if (list == null) return null;
                var listGrid = list.Select(x => x.GroupId).Distinct().ToList();
                var listGr = new List<ChatGroup>();
                foreach(var id in listGrid)
                {
                    listGr.Add(_context.ChatGroups.First(x => x.GroupId == id));
                }
                return JsonSerializer.Serialize(new AllGroup { list = listGr});
            } catch(Exception ex)
            {
                return "something went wrong";
            }
        }
    }
}
