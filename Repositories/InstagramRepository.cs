using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using Stalker.DTO;
using Stalker.Entities;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace Stalker.Repositories
{
    public class InstagramRepository : BaseRepository, IInstagramRepository
    {
        public InstagramRepository(IConfiguration configuration) : base(configuration)
        {

        }


        public InstagramAccountResponseDTO GetInstagramStatsFromJS(InstagramAccountRequestDTO req)
        {

            var uri = "https://www.instagram.com/" + req.username;
            var web = new HtmlWeb();


            var doc = web.Load(uri);

            var scripts = doc.DocumentNode.Descendants()
                .Where(n => n.Name == "script").TakeLast(10).ToList();

            var rawDataScript = scripts.First().InnerText.Replace("window._sharedData = ", "").Replace(";</script>", "").Replace(";", "");

            var data = JObject.Parse(rawDataScript);

            var IsPrivate = (bool)data["entry_data"]["ProfilePage"][0]["graphql"]["user"]["is_private"];

            if (!IsPrivate)
            {
                var result = new InstagramAccountDTO()
                {
                    Followers = data["entry_data"]["ProfilePage"][0]["graphql"]["user"]["edge_followed_by"]["count"].ToString(),
                    Following = data["entry_data"]["ProfilePage"][0]["graphql"]["user"]["edge_follow"]["count"].ToString(),
                    Posts = data["entry_data"]["ProfilePage"][0]["graphql"]["user"]["edge_owner_to_timeline_media"]["count"].ToString(),
                    IsPrivate = IsPrivate,
                    LastPostLikes = data["entry_data"]["ProfilePage"][0]["graphql"]["user"]["edge_owner_to_timeline_media"]["edges"][0]["node"]["edge_liked_by"]["count"].ToString(),
                    LastPostImageUri = data["entry_data"]["ProfilePage"][0]["graphql"]["user"]["edge_owner_to_timeline_media"]["edges"][0]["node"]["display_url"].ToString(),
                    uri = uri,
                    SnapShotTime = DateTime.Now,

                };


                using (var context = new InstagramContext())
                {


                    var instagramLog = new Instagram
                    {

                        Followers = result.Followers,
                        Following = result.Following,
                        Posts = result.Posts,
                        SnapShotTime = result.SnapShotTime,
                        uri = result.uri,
                        IsPrivate = result.IsPrivate

                    };
                    context.Add(instagramLog);
                    context.SaveChanges();
                }

                return new InstagramAccountResponseDTO { response = result };
            }

            if (IsPrivate)
            {
                var result = new InstagramAccountDTO()
                {
                    Followers = data["entry_data"]["ProfilePage"][0]["graphql"]["user"]["edge_followed_by"]["count"].ToString(),
                    Following = data["entry_data"]["ProfilePage"][0]["graphql"]["user"]["edge_follow"]["count"].ToString(),
                    Posts = data["entry_data"]["ProfilePage"][0]["graphql"]["user"]["edge_owner_to_timeline_media"]["count"].ToString(),
                    IsPrivate = IsPrivate,
                    LastPostLikes = null,
                    LastPostImageUri = null,
                    uri = uri,
                    SnapShotTime = DateTime.Now,



                };

                using (var context = new InstagramContext())
                {


                    var instagramLog = new Instagram
                    {

                        Followers = result.Followers,
                        Following = result.Following,
                        Posts = result.Posts,
                        SnapShotTime = result.SnapShotTime,
                        uri = result.uri,
                        IsPrivate = result.IsPrivate

                    };
                    context.Add(instagramLog);
                    context.SaveChanges();
                }

                return new InstagramAccountResponseDTO { response = result };

            }

            return null;



        }

    }
}
