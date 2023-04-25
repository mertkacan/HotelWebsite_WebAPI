﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DtoLayer.Dtos.RoomDto
{
    public class RoomAddDto // Room Class'ının DTO yapısını burada oluşturdum.
    {
        [Required(ErrorMessage ="Lütfen oda numarasını giriniz")]
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage ="Lütfen fiyat bilgisi giriniz")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Lütfen oda başlığı bilgisi giriniz")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen yatak sayısını belirtiniz")]
        public string BedCount { get; set; }

        [Required(ErrorMessage = "Lütfen banyo sayısını belirtiniz")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}
