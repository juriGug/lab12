using System;
using System.Collections.Generic;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        private IDictionary<string,IList<TUser>> _userFollower = new Dictionary<string,IList<TUser>>();
        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
        }

        public bool AddFollowedUser(string group, TUser user)
        {
        
            if (_userFollower.ContainsKey(group)){
                if(!_userFollower[group].Contains(user))
                    _userFollower[group].Add(user);
                else
                    return false;
            }
            else
            {
                _userFollower.Add(group, new List<TUser>());
                _userFollower[group].Add(user);
            }
            return true;
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                List<TUser> follow = new List<TUser>();
                foreach(var group in _userFollower.Values)
                {
                    foreach(var user in group){
                       follow.Add(user);
                    }
                }
                return follow;
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            if(_userFollower.ContainsKey(group))
                return _userFollower[group];
            return new List<TUser>();
        }
    }
}
