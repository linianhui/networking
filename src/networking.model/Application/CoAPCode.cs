using System;

namespace Networking.Model.Application
{
    /// <summary>
    /// <see cref="CoAP"/>的Code
    /// <see href="https://tools.ietf.org/html/rfc7252#section-12.1"/>
    /// </summary>
    public enum CoAPCode : Byte
    {
        #region 0.xx

        /// <summary>
        /// 0.01 GET
        /// </summary>
        GET = 0b_000_00001,

        /// <summary>
        /// 0.02 POST 
        /// </summary>
        POST = 0b_000_00010,

        /// <summary>
        /// 0.03 PUT 
        /// </summary>
        PUT = 0b_000_00011,

        /// <summary>
        /// 0.04 DELETE  
        /// </summary>
        DELETE = 0b_000_00100,

        #endregion


        #region 2.xx

        /// <summary>
        /// 2.01 Created 
        /// </summary>
        Created = 0b_010_00001,

        /// <summary>
        /// 2.02 Deleted 
        /// </summary>
        Deleted = 0b_010_00010,

        /// <summary>
        /// 2.03 Valid 
        /// </summary>
        Valid = 0b_010_00011,

        /// <summary>
        /// 2.04 Changed 
        /// </summary>
        Changed = 0b_010_00100,

        /// <summary>
        /// 2.05 Content 
        /// </summary>
        Content = 0b_010_00101,

        #endregion


        #region 4.xx

        /// <summary>
        /// 4.00 Bad Request 
        /// </summary>
        BadRequest = 0b_100_00000,

        /// <summary>
        /// 4.01 Unauthorized 
        /// </summary>
        Unauthorized = 0b_100_00001,

        /// <summary>
        /// 4.02 Bad Option 
        /// </summary>
        BadOption = 0b_100_00010,

        /// <summary>
        /// 4.03 Forbidden 
        /// </summary>
        Forbidden = 0b_100_00011,

        /// <summary>
        /// 4.04 Not Found
        /// </summary>
        NotFound = 0b_100_00100,

        /// <summary>
        /// 4.05 Method Not Allowed 
        /// </summary>
        MethodNotAllowed = 0b_100_00101,

        /// <summary>
        /// 4.06 Not Acceptable
        /// </summary>
        NotAcceptable = 0b_100_00110,

        /// <summary>
        /// 4.12 Precondition Failed 
        /// </summary>
        PreconditionFailed = 0b_100_01100,

        /// <summary>
        /// 4.13 Request Entity Too Large 
        /// </summary>
        RequestEntityTooLarge = 0b_100_01101,

        /// <summary>
        /// 4.15 Unsupported Content-Format 
        /// </summary>
        UnsupportedContentFormat = 0b_100_01111,

        #endregion

        #region 5.xx

        /// <summary>
        /// 5.00 Internal Server Error 
        /// </summary>
        InternalServerError = 0b_101_00000,

        /// <summary>
        /// 5.01 Not Implemented 
        /// </summary>
        NotImplemented = 0b_101_00001,

        /// <summary>
        /// 5.02 Bad Gateway 
        /// </summary>
        BadGateway = 0b_101_00010,

        /// <summary>
        /// 5.03 Service Unavailable 
        /// </summary>
        ServiceUnavailable = 0b_101_00011,

        /// <summary>
        /// 5.04 Gateway Timeout 
        /// </summary>
        GatewayTimeout = 0b_101_00100,

        /// <summary>
        /// 5.05 Proxy Not Supported 
        /// </summary>
        ProxyNotSupported = 0b_101_00101,

        #endregion
    }
}
