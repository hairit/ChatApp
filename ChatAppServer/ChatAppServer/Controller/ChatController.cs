﻿using ChatAppServer.Model;
using ChatAppServer.ServerSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.Controller
{
    public class ChatController
    {
        private readonly Context _context;
        public ChatController()
        {
            _context = new Context();
        }
        public async Task<bool> ChatHandler(Base json, List<Worker> workers, Worker from)
        {
            switch(json.action.ToLower())
            {
                case "send":
                    {
                        var model = new ChatMessage().GetFromJson(json.content);
                        return await sendChat(model, workers, from);
                    }
                    break;
                default: return false;
            }
            return false;
        }
        private async Task<bool> sendChat(ChatMessage mess, List<Worker> workers, Worker from)
        {
            try
            {
                var groupUsers = _context.GroupUsers.Where(x => x.GroupId == mess.GroupId).ToList();
                var message = new Base { action = "newmess", model = "chatmessage", content = mess.ParseToJson() };
                _context.ChatMessages.Add(mess);
                foreach (var user in groupUsers)
                {
                    if (workers.Any(x => x.Username == mess.ChatUser.Name)) workers.First(x => x.Username == mess.ChatUser.Name).Send(message.ParseToJson());
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
                
        }
    }
}
