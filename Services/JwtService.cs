using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using JWT.Exceptions;

namespace api_sena.Services
{
    public class JwtService
    {

        private readonly static string secretKey = "jwtsecretkey";

        static JwtService() {}

        public static string Encode(Dictionary<string, object> payload) {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(payload: payload, key: secretKey);
            return token;
        }
    }
}