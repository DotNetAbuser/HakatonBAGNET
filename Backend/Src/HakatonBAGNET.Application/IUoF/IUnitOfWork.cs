﻿namespace HakatonBAGNET.Application.IUoW;

public interface IUnitOfWork
{
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
}