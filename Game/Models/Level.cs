using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake.Models
{
    public class Level
    {
        private const int MIN_POINT = 5;

        private int _pointsSilver;
        private int _pointsRed;
        private int _pointsBlue;


        [XmlAttribute("id")]
        public int Id { get; set; }

        public int MaxScore { get; set; }

        public int Speed { get; set; }

        public int PointsSilver
        {
            get => _pointsSilver;
            set => _pointsSilver = value < MIN_POINT ? MIN_POINT : value;
        }

        public int PointsRed
        {
            get => _pointsRed;
            set => _pointsRed = value < MIN_POINT ? MIN_POINT : value;
        }

        public int PointsBlue
        {
            get => _pointsBlue;
            set => _pointsBlue = value < MIN_POINT ? MIN_POINT : value;
        }
    }
}
