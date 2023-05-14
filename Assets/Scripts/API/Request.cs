using System;

namespace API.Models
{
    #region Request
    [Serializable]
    public class Request{}
    
    public class ModelRequest : Request
    {
        public string objectUrl;
        public string materialUrl;
        public string imageUrl;
    }

    public class MaterialRequest : Request
    {
        public string materialUrl;
        public string imageUrl;
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
        public string objectUrl;
        public int materialId;
        public string imageUrl;
    }

    public class MaterialResponce : Responce
    {
        public int id;
        public int materialId;
        public string imageUrl;
    }
    #endregion
}