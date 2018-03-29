// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Util.Common
// 文件名：RedisCacheManager.cs
// 创建标识：吴来伟 2018-03-28 16:57
// 创建描述：
//  
// 修改标识：吴来伟2018-03-28 16:57
// 修改描述：
//  ------------------------------------------------------------------------------

using ServiceStack.Redis;
using System;
using WorkData.Util.Redis;
using Newtonsoft.Json;

namespace WorkData.NancyHost.Cache
{
    public class RedisCacheManager : ICacheManager
    {
        public IRedisClient RedisClientManager { get; set; }
        public RedisCacheManager()
        {
            RedisClientManager = NullRedis.Instance;
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(string key)
        {
            return RedisClientManager.ContainsKey(key);
        }

        public TEntity Get<TEntity>(string key)
        {
            return RedisClientManager.Get<TEntity>(key);
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
             RedisClientManager.Remove(key);
        }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheTime"></param>
        public void Set(string key, object value, DateTime cacheTime)
        {
             RedisClientManager.Add(key,value, cacheTime);
        }
    }
}