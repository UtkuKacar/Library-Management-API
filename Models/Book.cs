using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LibraryManagementAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required, Range(1, int.MaxValue)]
        public int PublishedYear { get; set; }

        [Required]
        public int AuthorId { get; set; }

        // navigation prop bind & JSON’tan çıkarıldı
        [BindNever]
        [JsonIgnore]
        public Author? Author { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
