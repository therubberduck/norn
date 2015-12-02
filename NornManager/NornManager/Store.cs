using NornManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NornManager
{
    public class Store
    {
        private static Store _instance;

        private List<Content> _content;
        private List<Content> _visibleContent;
        private List<string> _visibleContentTitles;
        public List<Content> Content
        {
            get {return _content;}
            set
            {
                _content = value;

                UpdateContentArrays();
            }
        }
        public List<Content> VisibleContent { get { return _visibleContent; } }
        public List<string> VisibleContentTitles { get { return _visibleContentTitles; } }
        public object[] ContentArray { get { return _content.ToArray(); } }
        public void AddContent(Content content)
        {
            _content.Add(content);
            UpdateContentArrays();
        }
        public void RemoveContent(Content content)
        {
            _content.Remove(content);
            UpdateContentArrays();
        }
        private void UpdateContentArrays()
        {
            _content = _content.OrderBy(c => c.title).ToList();

            _visibleContent = new List<Content>();
            _visibleContentTitles = new List<string>();
            foreach (Content item in _content.Where(item => item.Visible()))
            {
                _visibleContent.Add(item);
                _visibleContentTitles.Add(item.title);
            }
        }

        private List<User> _users;
        public List<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                _users = _users.OrderBy(u => u.userName).ToList();
            }
        }
        public object[] UsersArray { get { return _users.ToArray(); } }

        public static Store Get()
        {
            if(_instance == null)
            {
                _instance = new Store();
            }
            return _instance;
        }
    }
}
