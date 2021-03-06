﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace zhihuDaily.Model
{
    [DataContract]
    public class ReplyTo
    {
        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "id")]
        public long Id { get; set; }
      
        private string _author;
        [DataMember(Name = "author")]
        public string Author { get { return "//" + _author + " : "; } set { _author = value; } }

        [DataMember(Name = "own")]
        public bool Own { get; set; }
        [DataMember(Name = "voted")]
        public bool Voted { get; set; }
        [DataMember(Name = "time")]
        public int Time { get; set; }
        [DataMember(Name = "likes")]
        public int Likes { get; set; }
    }

    [DataContract]
    public class Comment:NotificationObject
    {
        [DataMember(Name = "own")]
        public bool Own { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "avatar")]
        public string Avatar { get; set; }

        [DataMember(Name = "time")]
        public long Time { get; set; }

        private bool voted;
        [DataMember(Name = "voted")]
        public bool Voted {
            get { return voted; }
            set {
                voted = value;
                RaisePropertyChanged(()=> Voted);
            }
        }

        [DataMember(Name = "id")]
        public long Id { get; set; }
        private int likes;
        [DataMember(Name = "likes")]
        public int Likes
        {
            get { return likes; }
            set {
                likes = value;
                RaisePropertyChanged(()=> Likes);
            }
        }

        [DataMember(Name = "reply_to")]
        public ReplyTo ReplyTo { get; set; }

    }
    [DataContract]
    public class Comments
    {
        [DataMember(Name = "comments")]
        public IEnumerable<Comment> CommentList { get; set; }
    }
}
