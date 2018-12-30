using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stalker
{
    [Serializable]
    [Table("Instagram_Log")]
    public class Instagram
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Following")]
        public string Following { get; set; }

        [Column("Followers")]
        public string Followers { get; set; }

        [Column("Posts")]
        public string Posts { get; set; }

        [Column("SnapShotTime")]
        public DateTime? SnapShotTime { get; set; }

        [Column("uri")]
        public string uri { get; set; }

        [Column("IsPrivate")]
        public bool IsPrivate { get; set; }

        [Column("LastPostLikes")]
        public string LastPostLikes { get; set; }

        [Column("LastPostImageUri")]
        public string LastPostImageUri { get; set; }
        

        [NotMapped]
        public int EntityId
        {
            get { return ID; }
            set { ID = value; }
        }

    }
}
