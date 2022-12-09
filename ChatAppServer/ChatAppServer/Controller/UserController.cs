using ChatAppServer.DTO;
using ChatAppServer.Model;
using ChatAppServer.ServerSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<bool> UserHandler(Base json, List<Worker> workers, Worker from)
        {
            switch (json.action.ToLower())
            {
                case "login":
                    {
                        var model = new Login().GetFromJson(json.content);
                        var response = new response { action = "login", content = await Login(model) };
                        from.Send(response.ParseToJson());
                        from.Username = model.UserName;
                        return true;
                    }
                    break;
                case "signup":
                    {
                        var model = new ChatUser().GetFromJson(json.content);
                        var response = new response { action = "register", content = await SignUp(model) };
                        from.Send(response.ParseToJson());
                        return true;
                    }
                    break;
                case "get":
                    {
                        var model = new GetUser().GetFromJson(json.content);
                        var response = new response { action = "get", content = await Get(model) };
                        from.Send(response.ParseToJson());
                        return true;
                    }
                    break;
                default:return false;
            }
            return false;
        }
        private async Task<string> Login(Login model)
        {
            if (!_context.ChatUsers.Any(x => x.UserName == model.UserName))
                return "Your username or password was wrong!";
            else
            {
                if (!_context.ChatUsers.Any(x => x.UserName == model.UserName))
                    return "Your username or password was wrong!";
                return "Login success!";
            }
        }
        private async Task<string> SignUp(ChatUser model)
        {
            try
            {
                if (_context.ChatUsers.Any(x => x.UserName == model.UserName)) return "Account conflict!";
                _context.ChatUsers.Add(model);
                await _context.SaveChangesAsync();
                return "Account created";
            }
            catch(Exception ex)
            {
                return "Something went wrong!";
            }
        }
        private async Task<string> Get(GetUser model)
        {
            if (!_context.ChatUsers.Any(x => x.UserName == model.UserName)) return "User is not exist!";
            var user = _context.ChatUsers.FirstOrDefault(x => x.UserName == model.UserName);
            return user.ParseToJson();
        }

    }
}
