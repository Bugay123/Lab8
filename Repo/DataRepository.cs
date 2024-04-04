using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab8.Models;
using System.Collections.Generic;
using System.Linq;
using Lab8.Models;

namespace Lab8.Repo
{
        public class DataRepository
        {
            public static List<MusicTrack> GetAllTracks()
            {
                using (var db = new MusicDbContext())
                {
                 return db.Tracks.ToList();
                }
            }

            public static void AddTrack(MusicTrack track)
            {
                using (var db = new MusicDbContext())
                {
                    db.Tracks.Add(track);
                    db.SaveChanges();
                }
            }

            public static void UpdateTrack(MusicTrack track)
            {
                using (var db = new MusicDbContext())
            {
                    db.Tracks.Update(track);
                    db.SaveChanges();
                }
            }

            public static void RemoveTrack(MusicTrack track)
            {
                using (var db = new MusicDbContext())
            {
                    db.Tracks.Remove(track);
                    db.SaveChanges();
                }
            }

            public static void RemoveAllTracks()
            {
                using (var db = new MusicDbContext())
                {
                var allTracks = db.Tracks.ToList();
                db.Tracks.RemoveRange(allTracks);
                db.SaveChanges();
                }
            }
        }
    }
