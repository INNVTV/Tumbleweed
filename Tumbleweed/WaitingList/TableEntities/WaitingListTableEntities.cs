using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tumbleweed.WaitingList.TableEntities
{
    public class WaitingListTableEntity_ByAlphabet : TableEntity
    {
        public WaitingListTableEntity_ByAlphabet(string email)
        {
            this.PartitionKey = email;

            this.RowKey = string.Format("{0:d19}+{1}", DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks, Guid.NewGuid().ToString("N"));
        }


        public WaitingListTableEntity_ByAlphabet() { }

    }

    internal class WaitingListTableEntity_ByTime : TableEntity
    {
        public WaitingListTableEntity_ByTime(string email)
        {
            this.PartitionKey = string.Format("{0:d19}+{1}", DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks, Guid.NewGuid().ToString("N"));;

            this.RowKey = email;
        }


        public WaitingListTableEntity_ByTime() { }

    }
}