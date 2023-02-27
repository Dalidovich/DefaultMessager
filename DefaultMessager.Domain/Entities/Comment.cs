﻿using DefaultMessager.Domain.Enums;

namespace DefaultMessager.Domain.Entities
{
    public class Comment
    {
        public Guid? Id { get; set; }
        public Guid PostId { get; set; }
        public Guid AccountId { get; set; }
        public string? CommentTextContent { get; set; }
        public DateTime DatePublicate { get; set; }
        public StatusComment CommentStatus { get; set; }
        public Post? Post { get; set; }
        public Account? Account { get; set; }
        public Comment(Guid postId, Guid accountId, string commentText, DateTime datePublicate, StatusComment status)
        {
            PostId = postId;
            AccountId = accountId;
            CommentTextContent = commentText;
            DatePublicate = datePublicate;
            CommentStatus = status;
        }
        public Comment()
        {
        }
        public Comment(Guid postId, Guid id, string commentContent)
        {
            PostId = postId;
            AccountId = id;
            CommentTextContent = commentContent;
            DatePublicate = DateTime.Now;
            CommentStatus = StatusComment.normal;
        }
    }
}
