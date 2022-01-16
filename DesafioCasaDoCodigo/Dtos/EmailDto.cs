using DesafioCasaDoCodigo.Enums;

namespace DesafioCasaDoCodigo.Dtos
{
    public class EmailDto
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public EStatusEmail Status { get; set; }
    }
}