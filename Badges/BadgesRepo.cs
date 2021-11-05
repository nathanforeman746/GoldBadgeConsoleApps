using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class BadgesRepo
    {
        private Dictionary<int, List<string>> _accessList = new Dictionary<int, List<string>>();

        //create
        public void AddToAccessList(Badge badge)
        {
            _accessList.Add(badge.BadgeID, badge.Doors);
        }

        //Read
        public Dictionary<int, List<string>> GetAccessList()
        {
            return _accessList;
        }

        //Update
        public bool UpdateAccessList(int id, string newDoor, string oldDoor)
        {
            foreach (KeyValuePair<int, List<string>> badge in _accessList)
            {
                if (badge.Key == id)
                {
                    List<string> doors = badge.Value;
                    for (int i = 0; i < doors.ToArray().Length; ++i)
                    {
                        if (oldDoor == doors[i])
                        {
                            doors[i] = newDoor;
                            doors.ToList();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        //add
        public bool AddDoor(int id, string door)
        {
            foreach(KeyValuePair<int, List<string>> badge in _accessList)
            {
                if(badge.Key == id)
                {
                    List<string> doors = badge.Value;
                    doors.Add(door);
                    return true;
                }
            }
            return false;
        }
        //Delete
        public bool DeleteDoor(int id, string oldDoor)
        {
            foreach(KeyValuePair<int, List<string>> badge in _accessList)
            {
                if(badge.Key == id)
                {
                    List<string> doors = badge.Value;
                    for(int i = 0; i < doors.ToArray().Length; i++)
                    {
                        if(oldDoor == doors[i])
                        {
                            doors.RemoveAt(i);
                            doors.ToList();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        //find ID
        public Badge GetBadgeID(int id)
        {
            Badge returnBadge = new Badge();
            foreach(KeyValuePair<int, List<string>> badge in _accessList)
            {
                if (badge.Key == id)
                {
                    returnBadge.BadgeID = id;
                    returnBadge.Doors = badge.Value;
                    return returnBadge;
                }
            }
            return null;
        }
    }
}
