﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//建立加密位图添加类
class EncryptSpriteAdder
{
    public string encrypt_sign;
    //生成加密位图添加部分
    public JObject EncryptSpriteAdd(JObject rss)
    {
        try
        {
            Console.WriteLine("输入用于加密的标识以创建记录（不输入直接按回车默认不创建记录）");
            encrypt_sign = Console.ReadLine();
            if (encrypt_sign == "") { }
            else
            {
                //读取resources作为JArray
                JArray resources = JArray.Parse(rss["resources"].ToString());
                //记录其中一个位图资源作为记录
                JObject encrypt_res = new JObject();
                //遍历获取各个位图信息
                foreach (JObject resource in resources)
                {
                    if (resource.ContainsKey("atlas")) { }
                    else
                    {
                        //获取最后一位
                        if (resources.IndexOf(resource) == resources.Count - 2 || resources.IndexOf(resource) == resources.Count - 1)
                        {
                            encrypt_res = JObject.Parse(resource.ToString());
                        }
                        else { }
                    }
                }
                //进行修改
                //判定
                if (encrypt_res.ContainsKey("ax"))
                {
                    encrypt_res["ax"] = 0;
                }
                if (encrypt_res.ContainsKey("ay"))
                {
                    encrypt_res["ay"] = 0;
                }
                if (encrypt_res.ContainsKey("aw"))
                {
                    encrypt_res["aw"] = 0;
                }
                if (encrypt_res.ContainsKey("ah"))
                {
                    encrypt_res["ah"] = 0;
                }
                if (!encrypt_res.ContainsKey("ax"))
                {
                    encrypt_res.Property("parent").AddAfterSelf(new JProperty("ax", 0));
                }
                if (!encrypt_res.ContainsKey("ay"))
                {
                    encrypt_res.Property("ax").AddAfterSelf(new JProperty("ay", 0));
                }
                if (!encrypt_res.ContainsKey("aw"))
                {
                    encrypt_res.Property("ay").AddAfterSelf(new JProperty("aw", 0));
                }
                if (!encrypt_res.ContainsKey("ah"))
                {
                    encrypt_res.Property("aw").AddAfterSelf(new JProperty("ah", 0));
                }
                else { }
                //编辑path和id
                //读取path作为JArray
                JArray path = JArray.Parse(encrypt_res["path"].ToString());
                //记录旧最后一位名称
                string spath = path[path.Count - 1].ToString();
                //将最后一位变成加密标识
                path[path.Count - 1] = encrypt_sign;
                //将path覆盖
                encrypt_res["path"] = path;
                //替换id
                encrypt_res["id"] = encrypt_res["id"].ToString().Replace("_"+spath.ToUpper(), "_"+encrypt_sign.ToUpper());
                encrypt_res["id"] = encrypt_res["id"].ToString().Replace(spath.ToUpper(),encrypt_sign.ToUpper());

                //在总组添加新记录
                resources.Add(encrypt_res);

                Console.WriteLine("加密标识信息添加完成");
                //覆盖原总组
                rss["resources"] = resources;
                EncryptSpriteAdd(rss);
            }
        }
        catch
        {
            Console.WriteLine("EncryptSpriteAdd ERROR!");
            //提示按任意键继续
            Console.WriteLine("Press any key to continue...");
            //输入任意键退出
            Console.ReadLine();
        }
        //修改记录中的位图信息为自定义的位图信息
        return rss;
    }
}