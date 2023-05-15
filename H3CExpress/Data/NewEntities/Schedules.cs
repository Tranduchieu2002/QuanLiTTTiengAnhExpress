namespace H3CExpress.Data.NewEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Schedules
    {
        public int id { get; set; }

        public DateTime start_time { get; set; }

        public DateTime end_time { get; set; }

        public TimeSpan learning_time { get; set; }
    }
}
