using System;

namespace API.Models
{
    #region Request
    [Serializable]
    public class Request{}
    
    public class ModelRequest : Request
    {
        public byte[] objectUrl;
        public byte[] materialId;
        public byte[] imageUrl;
    }

    public class MaterialRequest : Request
    {
        public byte[] imageUrl;
        public byte[] materialUrl;
    }

    public class GetByIdRequest : Request
    {
        public int id;
    }
    
    #endregion

    #region Responce
    [Serializable]
    public class Responce{}

    public class ModelResponce : Responce
    {
        public int id;
        public byte[] objectUrl;
        public byte[] materialId;
        public byte[] imageUrl;
    }

    public class MaterialResponce : Responce
    {
        public int id;
        public byte[] materialUrl;
        public byte[] imageUrl;
    }
    #endregion
}