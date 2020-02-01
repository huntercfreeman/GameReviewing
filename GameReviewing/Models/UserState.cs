using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReviewing.Models
{
    public class UserState
    {
        private string _username;
        public string Username 
        {
            get 
            {
                if(string.IsNullOrEmpty(_username))
                    return "Guest";

                return _username;
            }
            set
            {
                _username = value;
                UserStateChangedEventInvoke(new EventArgs());
            }
        }

        public event EventHandler UserStateChangedEventHandler;

        public void UserStateChangedEventInvoke(EventArgs e)
        {
            EventHandler handler = UserStateChangedEventHandler;
            handler?.Invoke(this, new EventArgs());
        }
    }
}
