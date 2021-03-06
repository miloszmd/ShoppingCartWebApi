﻿using System.Collections.Generic;
using ShoppingCart.Core.Communication;

namespace ShoppingCart.Data.Voucher
{
    public class GetVoucherByIdResponse : CommunicationResponse
    {
        public GetVoucherByIdResponse()
        {
            AllowedDeliveryTypes = new List<VoucherDeliveryTypeRecord>();
            AllowedSizes = new List<VoucherSizeRecord>();
        }

        public VoucherRecord Voucher { get; set; }
        public List<VoucherDeliveryTypeRecord> AllowedDeliveryTypes { get; set; }
        public List<VoucherSizeRecord> AllowedSizes { get; set; }
    }
}