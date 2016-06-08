using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CoolPhone.Models;

namespace CoolPhone.Data
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider sp)
        {
            var db = sp.GetService<ApplicationDbContext>();
            db.Database.EnsureCreated();

            if (!db.Blogs.Any())
            {
                var blogs = new Blog[]
                {
                    new Blog
                    {
                        Title = "Let's Learn JavaScript",
                        Message = "Blah blah blah...",
                        Comments = new List<Comment>
                        {
                            new Comment { Message = "Thanks this was awesome!!!" },
                            new Comment { Message = "This wasn't too helpful" },
                            new Comment { Message = "I still dont' understand" },
                            new Comment { Message = "two thumbs up" },
                        }
                    },
                    new Blog
                    {
                        Title = "Let's Learn TypeSCript",
                        Message = "Blah blah blah...",
                        Comments = new List<Comment>
                        {
                            new Comment { Message = "Sweet" },
                            new Comment { Message = "Thanks!" }
                        }
                    },
                    new Blog
                    {
                        Title = "Let's Learn ECMAScript 2015",
                        Message = "Blah blah blah...",
                        Comments = new List<Comment>
                        {
                            new Comment { Message = "Whoa this is so cool!" },
                            new Comment { Message = "This is the future of JavaScript!" },
                            new Comment { Message = "Nah... I like Ruby better" },
                            new Comment { Message = "Ruby is not as cool!" },
                        }
                    },
                };

                db.Blogs.AddRange(blogs);
                db.SaveChanges();
            }


            if (!db.Cars.Any())
            {
                db.Cars.AddRange(
                    new Car { Year = 2000, Make = "BMW", Model = "M5" },
                    new Car { Year = 2002, Make = "Ford", Model = "Explorer" },
                    new Car { Year = 2004, Make = "VW", Model = "GTI" },
                    new Car { Year = 2006, Make = "Hyundai", Model = "Genesis" }
                );

                db.SaveChanges();
            };

        }
    }
}
