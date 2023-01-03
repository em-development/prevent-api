using System.Data;
using Domain.Entities.Base;
using Domain.ValueObjects.Files;
using Domain.ValueObjects.General;

namespace Domain.Entities.Files
{
    public class Attachment : Entity
    {
        public GuId Guid { get; private set; }
        public FileName FileName { get; private set; }
        public ContentType ContentType { get; private set; }
        public Bucket Bucket { get; private set; }

        #region EF Constructor

#pragma warning disable CS8618
        private Attachment()
        {
        }
#pragma warning restore CS8618

        #endregion EF Constructor

        public Attachment(string guid, string fileName, string contentType, string bucket)
        {
            Guid = GuId.CreateValid(guid, GetType().Name.ToLower());
            FileName = FileName.CreateValid(fileName, GetType().Name.ToLower());
            ContentType = ContentType.CreateValid(contentType, GetType().Name.ToLower());
            Bucket = Bucket.CreateValid(bucket, GetType().Name.ToLower());
        }

        public void Update(string fileName, string contentType)
        {
            FileName = FileName.CreateValid(fileName, GetType().Name.ToLower());
            ContentType = ContentType.CreateValid(contentType, GetType().Name.ToLower());
        }
    }
}