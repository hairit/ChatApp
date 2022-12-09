using ChatAppServer.DTO;
using ChatAppServer.Model;
using ChatAppServer.ServerSocket;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatAppServer.Controller
{
    public class UserController
    {
        private readonly Context _context;

        public UserController()
        {
            _context = new Context();
        }

        public void UserHandler(Base json, List<Worker> workers, Worker from)
        {
            switch (json.action.ToLower())
            {
                case "login":
                {
                    var model = new Login().GetFromJson(json.content);
                    var response = new response { action = "login", content = Login(model).Result };
                    from.Send(response.ParseToJson());
                    from.Username = model.UserName;
                    break;
                }
                case "register":
                {
                    var model = new ChatUser().GetFromJson(json.content);
                    var response = new response { action = "register", content = SignUp(model).Result };
                    from.Send(response.ParseToJson());
                    break;
                }

                case "get":
                {
                    var model = new GetUser().GetFromJson(json.content);
                    var response = new response { action = "get", content = Get(model).Result };
                    from.Send(response.ParseToJson());
                    break;
                }
                case "getbyname":
                {
                    var model = new GetUserByName().GetFromJson(json.content);
                    var response = new response { action = "getbyname", content = GetUserByName(model).Result };
                    from.Send(response.ParseToJson());
                    break;
                }

                case "changepass":
                {
                    var model = new ChangePass().GetFromJson(json.content);
                    var response = new response { action = "changepass", content = ChangePage(model).Result };
                    break;
                }
                default:
                    break;
            }
        }

        private async Task<string> Login(Login model)
        {
            if (!_context.ChatUsers.Any(x => x.UserName == model.UserName))
                return "Your username or password was wrong!";
            else
            {
                if (!_context.ChatUsers.Any(x => x.UserName == model.UserName))
                    return "Your username or password was wrong!";
                return _context.ChatUsers.First(x => x.UserName == model.UserName).ParseToJson();
            }
        }

        private async Task<string> SignUp(ChatUser model)
        {
            try
            {
                if (_context.ChatUsers.Any(x => x.UserName == model.UserName)) return "account conflict";
                _context.ChatUsers.Add(model);
                await _context.SaveChangesAsync();
                return "successfully created";
            }
            catch (Exception ex)
            {
                return "something went wrong";
            }
        }

        private async Task<string> Get(GetUser model)
        {
            if (!_context.ChatUsers.Any(x => x.UserName == model.UserName)) return "user is not exist";
            var user = _context.ChatUsers.FirstOrDefault(x => x.UserName == model.UserName);
            return user.ParseToJson();
        }

        private async Task<string> GetUserByName(GetUserByName model)
        {
            var users = _context.ChatUsers.Where(x => x.Name.Contains(model.Name)).ToList();
            return JsonSerializer.Serialize(users);
        }

        private async Task<string> ChangePage(ChangePass model)
        {
            try
            {
                if (_context.ChatUsers.Any(x => x.UserName == model.UserName))
                {
                    var user = _context.ChatUsers.First(x => x.UserName == model.UserName);
                    if (user.Password != model.CurrentPass) return "your current password is wrong";
                    _context.ChatUsers.Remove(user);
                    user.Password = model.CurrentPass;
                    _context.ChatUsers.Add(user);
                    await _context.SaveChangesAsync();
                    return "Your password changed";
                }
                else
                    return "something went wrong";
            }
            catch (Exception ex)
            {
                return "some thing went wrong, please contact your admin";
            }
        }
    }
}