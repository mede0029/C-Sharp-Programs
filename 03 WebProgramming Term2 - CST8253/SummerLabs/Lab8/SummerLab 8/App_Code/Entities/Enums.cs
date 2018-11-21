﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Enums
/// </summary>
public enum TransactionResult
{
    SUCCESS,
    INSUFFICIENT_FUND,
    EXCEED_MAX_WITHDRAW_AMOUNT,
    PENDING
}

public enum CustomerStatus
{
    REGULAR,
    PRIMIER
}