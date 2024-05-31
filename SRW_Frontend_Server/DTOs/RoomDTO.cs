namespace SRW_Frontend_Server.DTOs
{
    public class RoomDTO
    {
        public int Room_ID { get; set; }

        public int RoomType_ID { get; set; }

        public int Image_ID { get; set; }

        public string Room_Name { get; set; }

        public int? Room_Number { get; set; }

        public int Room_Floor { get; set; }

        public string? Room_Description { get; set; }

        public RoomTypeDTO? RoomType { get; set; }
        public ImageDTO? Image { get; set; }
    }
}
