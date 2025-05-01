using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LibraryManagementAPI.Models
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [BindNever]
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
