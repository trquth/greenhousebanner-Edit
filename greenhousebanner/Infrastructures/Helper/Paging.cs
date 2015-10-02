using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;

namespace greenhousebanner.Infrastructures.Helper
{
    public class Paging
    {
        public int pagedisplay { get; set; }

        public int rowsdisplay { get; set; }

        public Paging()
        {
            this.pagedisplay = int.Parse(WebConfigurationManager.AppSettings["pagedisplay"].ToString());
            this.rowsdisplay = int.Parse(WebConfigurationManager.AppSettings["rowsdisplay"].ToString());
        }

        //show paging 
        public static string Page(int pageindex, int total)
        {
            string rawHTML = "<ul class='pagging'>";

            //default value page index
            int index = pageindex;

            //Info paging
            Paging infopage = new Paging();


            int maxrecord = total; // max record

            //max count page
            int maxpage = maxrecord / infopage.rowsdisplay;
            if (maxpage % infopage.rowsdisplay > 0)
                maxpage = maxpage + 1;

            //page start
            int start = (index / infopage.pagedisplay) * infopage.pagedisplay;
            if (start == 0)
                start = 1;

            //page end
            int end = start + infopage.pagedisplay;
            if (pageindex >= infopage.pagedisplay)
                end = end + 1;
            //page next
            //int next = index + 1;

            //page previous
            //int pre = index - 1;

            //show First page
            if (index > 1)
                rawHTML = rawHTML + "<li><a href='?page=1' ><div>&lt;&lt;</div></a><li>";

            //list page
            for (int i = start; i < maxpage && i < end; i++)
            {
                if (i == index)
                    rawHTML = rawHTML + "<li><a class='active' href='#'><div>" + i + "</div></a><li>";
                else
                    rawHTML = rawHTML + "<li><a href='?page=" + i + "' ><div>" + i + "</div></a><li>";
            }

            //show Last page
            if (index < maxpage)
                rawHTML = rawHTML + "<li><a href='?page=" + maxpage + "' ><div>&gt;&gt;</div></a><li>";

            return rawHTML + "</ul>";
        }

    }
}