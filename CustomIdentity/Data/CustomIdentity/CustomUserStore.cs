﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomIdentity.Data.CustomIdentity
{
    public class CustomUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>
    {
        private ApplicationDbContext context;
        public CustomUserStore(ApplicationDbContext context)
        {
            this.context = context;
        }

        #region IUserStore implementation
        public Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            cancellationToken.ThrowIfCancellationRequested();

            return Task.Factory.StartNew(() =>
            {
                ApplicationUser user = null;
                try
                {
                    user = this.context.Users.Find(Int32.Parse(userId));
                }
                catch (Exception)
                {
                    throw;
                }
                return user;
            }, cancellationToken);
        }

        public Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                ApplicationUser user = null;
                try
                {
                    user = this.context.Users.FindUserByName(normalizedUserName.ToLower()) as ApplicationUser;
                }
                catch (Exception)
                {
                    throw;
                }
                return user;
            }, cancellationToken);
        }

        public Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Task.FromResult(user.Username);
        }

        public Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            cancellationToken.ThrowIfCancellationRequested();

            return Task.Factory.StartNew(() =>
            {
                IdentityResult identityResult;
                try
                {
                    context.Users.Add(user);
                    identityResult = IdentityResult.Success;
                }
                catch (Exception e)
                {
                    var identityError = new IdentityError { Description = e.Message };
                    identityResult = IdentityResult.Failed(identityError);
                }
                return identityResult;
            }, cancellationToken);
        }

        public Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Task.Factory.StartNew(() =>
            {
                var ir = new IdentityResult();
                try
                {
                    context.Users.Delete(user);
                    ir = IdentityResult.Success;

                }
                catch (Exception e)
                {
                    var identityError = new IdentityError { Description = e.Message };
                    ir = IdentityResult.Failed(identityError);
                }
                return ir;
            }, cancellationToken);
        }

        public Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        {
            user.Username = userName;
            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Password hashing
        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                user.Password = passwordHash;
            });
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            bool result = user.Password != null ? true : false;
            return Task.FromResult(result);
        }
        #endregion

        #region IDisposable
        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        private bool _disposed;
        public void Dispose()
        {
            this._disposed = true;
        }
        #endregion


    }



}

