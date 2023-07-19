﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MvcStartApp.Models.Db
{
    [Table("Requests")]
    public class Request
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
        public Request()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
            Url = string.Empty;
        }
    }
}
