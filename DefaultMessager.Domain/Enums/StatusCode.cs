using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Domain.Enums
{
    public enum StatusCode
    {
        commentCreate=0,
        commentUpdate=1,
        commentDelete=2,
        commentRead=3,

        DescriptionUserCreate=10,
        DescriptionUserUpdate=11,
        DescriptionUserDelete=12,
        DescriptionUserRead  =13,

        ImageAlbumCreate=20,
        ImageAlbumUpdate=21,
        ImageAlbumDelete=22,
        ImageAlbumRead  =23,

        LikeCreate=30,
        LikeUpdate=31,
        LikeDelete=32,
        LikeRead = 33,

        MessageCreate=40,
        MessageUpdate=41,
        MessageDelete=42,
        MessageRead = 43,

        PostCreate=50,
        PostUpdate=51,
        PostDelete=52,
        PostRead = 53,

        UserCreate=60,
        UserUpdate=61,
        UserDelete=62,
        UserRead = 63,

        OK = 200,
        InternalServerError = 500
    }
}
