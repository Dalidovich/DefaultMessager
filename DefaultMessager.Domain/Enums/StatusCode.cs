namespace DefaultMessager.Domain.Enums
{
    public enum StatusCode
    {
        EntityNotFound = 0,

        EntityUpdate = 1,
        EntityDelete = 2,
        EntityRead = 3,
        EntityCreate = 4,

        CommentCreate = 10,
        CommentUpdate = 11,
        CommentDelete = 12,
        CommentRead = 13,

        DescriptionAccountCreate = 20,
        DescriptionAccountUpdate = 21,
        DescriptionAccountDelete = 22,
        DescriptionAccountRead = 23,

        ImageAlbumCreate = 30,
        ImageAlbumUpdate = 31,
        ImageAlbumDelete = 32,
        ImageAlbumRead = 33,
        PhotoDelete = 34,

        LikeCreate = 40,
        LikeUpdate = 41,
        LikeDelete = 42,
        LikeRead = 43,

        MessageCreate = 50,
        MessageUpdate = 51,
        MessageDelete = 52,
        MessageRead = 53,

        PostCreate = 60,
        PostUpdate = 61,
        PostDelete = 62,
        PostRead = 63,

        AccountCreate = 70,
        AccountUpdate = 71,
        AccountDelete = 72,
        AccountRead = 73,
        AccountAuthenticate = 74,

        FileUpload=80,
        FileUploadFailed=81,

        OK = 200,
        OKNoContent = 204,
        InternalServerError = 500,
    }
}
