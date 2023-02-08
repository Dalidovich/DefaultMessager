using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Domain.Enums
{
    public enum StatusCode
    {
        EntityCreate = 0,
        EntityUpdate = 1,
        EntityDelete = 2,
        EntityRead = 3,

        commentCreate =10,
        commentUpdate=11,
        commentDelete=12,
        commentRead=13,

        DescriptionUserCreate=20,
        DescriptionUserUpdate=21,
        DescriptionUserDelete=22,
        DescriptionUserRead  =23,

        ImageAlbumCreate=30,
        ImageAlbumUpdate=31,
        ImageAlbumDelete=32,
        ImageAlbumRead  =33,

        LikeCreate=40,
        LikeUpdate=41,
        LikeDelete=42,
        LikeRead = 43,

        MessageCreate=50,
        MessageUpdate=51,
        MessageDelete=52,
        MessageRead = 53,

        PostCreate=60,
        PostUpdate=61,
        PostDelete=62,
        PostRead = 63,

        UserCreate=70,
        UserUpdate=71,
        UserDelete=72,
        UserRead = 73,

        OK = 200,
        InternalServerError = 500
    }
}
