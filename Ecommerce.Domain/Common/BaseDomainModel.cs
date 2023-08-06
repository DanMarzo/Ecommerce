﻿namespace Ecommerce.Domain.Common;

public abstract class BaseDomainModel
{
    public int Cod { get; set; }
    public DateTime? CreateDate { get; set; }
    public string CreateBy { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public DateTime LastModifiedBy { get; set; }
}