using System;


namespace Stalker.Entities
{
    public class InstagramAccountDTO
    {

        public string Following { get; set; }

        public string Followers { get; set; }

        public string Posts { get; set; }

        public DateTime SnapShotTime { get; set; }

        public string uri { get; set; }

        public bool IsPrivate { get; set; }

        public string LastPostLikes { get; set; }

        public string LastPostImageUri { get; set; }
    }
}
