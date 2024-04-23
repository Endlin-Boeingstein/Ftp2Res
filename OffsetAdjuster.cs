using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

//建立偏移调整类
public class OffsetAdjuster
{
    //生成偏移计算调整部分
    public JObject OffsetMove(JObject resource,int xadd,int yadd)
    {
        //判定是否存在偏移
        if (resource.ContainsKey("x") && resource.ContainsKey("y"))
        {
            resource["x"] = (int)resource["x"] + xadd;
            resource["y"] = (int)resource["y"] + yadd;
        }
        else
        {
            if (!resource.ContainsKey("x"))
            {
                resource.Property("ah").AddAfterSelf(new JProperty("x", xadd));
            }
            if (!resource.ContainsKey("y"))
            {
                resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
            }
        }
        return resource;
    }
    //生成偏移调整部分
    public JObject OffsetAdjust(JObject rss)
    {
        /*JSON结构化，半完工，20240310放弃
        JArray resources = JArray.Parse(rss["resources"].ToString());
        foreach (JObject res in resources)
        {

            if ((bool)res["atlas"])
            {
                AtlasStruct as= new AtlasStruct((bool)res["atlas"], (int)res["width"], (int)res["height"], res["slot"].ToString(), res["id"].ToString(), res["path"], res["type"]);
            }
            else
            {

            }
        }
        ResourceStruct rs= new ResourceStruct(rss["id"].ToString(), rss["type"].ToString(), rss["parent"].ToString(), rss["res"].ToString(), );
        */
        try
        {
            //卡槽自动判定
            if (rss["parent"].ToString() == "UI_SeedPackets")
            {
                //定义x和y要增加的量
                int xadd = 0;
                int yadd = 0;
                string selected;
                ArrayList al = new ArrayList();
                Console.WriteLine("请选择对应类型的卡槽结构类型以进行自定义统一计算（回车代表不进行计算）\n1.卡槽世界背景\n2.植物\n3.冷却\n4.选择框\n5.右下角标\n6.下框点线\n7.能量闪电框\n8.金银铜等级牌\n9.植物锁\n10.禁植物图标\n11.家族圆形背景\n12.家族图标\n13.未来瓷砖\n14.上框点线\n15.商店种子包");
                selected = Console.ReadLine();
                if (selected == "") { }
                else
                {
                    Console.WriteLine("请输入x相对原来偏移量：");
                    xadd = int.Parse(Console.ReadLine());
                    Console.WriteLine("请输入y相对原来偏移量：");
                    yadd = int.Parse(Console.ReadLine());

                    //读取resources作为JArray
                    JArray resources = JArray.Parse(rss["resources"].ToString());
                    //遍历获取各个位图信息
                    foreach (JObject resource in resources)
                    {
                        if (resource.ContainsKey("atlas")) { }
                        else
                        {
                            if (int.Parse((string)resource["aw"]) == 238 && selected == "1" && resource["id"].ToString() != "IMAGE_UI_STOREMULTI_SEEDPACKETICON" && !resource["id"].ToString().Contains("IMAGE_UI_PACKETS_TOOLS_PROJECTILE_BOWLINGBULB"))
                            {
                                //判定是否存在偏移
                                if (resource.ContainsKey("x"))
                                {
                                    resource["x"] = (int)resource["x"] + xadd;
                                }
                                else
                                {
                                    if (!resource.ContainsKey("x"))
                                    {
                                        resource.Property("ah").AddAfterSelf(new JProperty("x", xadd));
                                    }
                                }
                                //20240323修改修复y无法计算问题
                                if (int.Parse((string)resource["ah"]) == 150 && selected == "1")
                                {
                                    //判定是否存在偏移
                                    if (resource.ContainsKey("y"))
                                    {
                                        resource["y"] = (int)resource["y"] + yadd;
                                    }
                                    else
                                    {
                                        if (!resource.ContainsKey("y"))
                                        {
                                            resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                        }
                                    }
                                }
                                else if (int.Parse((string)resource["ah"]) == 151 && selected == "1")
                                {
                                    //判定是否存在偏移
                                    if (resource.ContainsKey("y"))
                                    {
                                        resource["y"] = (int)resource["y"] + yadd;
                                    }
                                    else
                                    {
                                        if (!resource.ContainsKey("y"))
                                        {
                                            resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                        }
                                    }
                                }
                                else { }
                            }
                            else if (int.Parse((string)resource["aw"]) == 239 && selected == "1" && resource["id"].ToString() != "IMAGE_UI_STOREMULTI_SEEDPACKETICON" && !resource["id"].ToString().Contains("IMAGE_UI_PACKETS_TOOLS_PROJECTILE_BOWLINGBULB"))
                            {
                                //判定是否存在偏移
                                if (resource.ContainsKey("x"))
                                {
                                    resource["x"] = (int)resource["x"] + xadd;
                                }
                                else
                                {
                                    if (!resource.ContainsKey("x"))
                                    {
                                        resource.Property("ah").AddAfterSelf(new JProperty("x", xadd));
                                    }
                                }
                                //20240323修改修复y无法计算问题
                                if (int.Parse((string)resource["ah"]) == 150 && selected == "1")
                                {
                                    //判定是否存在偏移
                                    if (resource.ContainsKey("y"))
                                    {
                                        resource["y"] = (int)resource["y"] + yadd;
                                    }
                                    else
                                    {
                                        if (!resource.ContainsKey("y"))
                                        {
                                            resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                        }
                                    }
                                }
                                else if (int.Parse((string)resource["ah"]) == 151 && selected == "1")
                                {
                                    //判定是否存在偏移
                                    if (resource.ContainsKey("y"))
                                    {
                                        resource["y"] = (int)resource["y"] + yadd;
                                    }
                                    else
                                    {
                                        if (!resource.ContainsKey("y"))
                                        {
                                            resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                        }
                                    }
                                }
                                else { }
                            }
                            else if (resource["id"].ToString() == "IMAGE_UI_PACKETS_COOLDOWN" && selected == "3")
                            {
                                //判定是否存在偏移
                                if (resource.ContainsKey("x"))
                                {
                                    resource["x"] = (int)resource["x"] + xadd;
                                }
                                if (resource.ContainsKey("y"))
                                {
                                    resource["y"] = (int)resource["y"] + yadd;
                                }
                                if (!resource.ContainsKey("x"))
                                {
                                    resource.Property("ah").AddAfterSelf(new JProperty("x", xadd));
                                }
                                if (!resource.ContainsKey("y"))
                                {
                                    resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                }
                            }
                            else if (resource["id"].ToString() == "IMAGE_UI_PACKETS_SELECT" && selected == "4")
                            {
                                //判定是否存在偏移
                                if (resource.ContainsKey("x"))
                                {
                                    resource["x"] = (int)resource["x"] + xadd;
                                }
                                if (resource.ContainsKey("y"))
                                {
                                    resource["y"] = (int)resource["y"] + yadd;
                                }
                                if (!resource.ContainsKey("x"))
                                {
                                    resource.Property("ah").AddAfterSelf(new JProperty("x", xadd));
                                }
                                if (!resource.ContainsKey("y"))
                                {
                                    resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                }
                            }
                            else if (resource["id"].ToString().Contains("_PRICE_TAB") && selected == "5")
                            {
                                //判定是否存在偏移
                                if (resource.ContainsKey("x"))
                                {
                                    resource["x"] = (int)resource["x"] + xadd;
                                }
                                if (resource.ContainsKey("y"))
                                {
                                    resource["y"] = (int)resource["y"] + yadd;
                                }
                                if (!resource.ContainsKey("x"))
                                {
                                    resource.Property("ah").AddAfterSelf(new JProperty("x", xadd));
                                }
                                if (!resource.ContainsKey("y"))
                                {
                                    resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                }
                            }
                            else if (resource["id"].ToString().Contains("_DOTS_") && selected == "6")
                            {
                                //判定是否存在偏移
                                if (resource.ContainsKey("x"))
                                {
                                    resource["x"] = (int)resource["x"] + xadd;
                                }
                                if (resource.ContainsKey("y"))
                                {
                                    resource["y"] = (int)resource["y"] + yadd;
                                }
                                if (!resource.ContainsKey("x"))
                                {
                                    resource.Property("ah").AddAfterSelf(new JProperty("x", xadd));
                                }
                                if (!resource.ContainsKey("y"))
                                {
                                    resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                }
                            }
                            else if (resource["id"].ToString().Contains("_ICON") && selected == "7")
                            {
                                //判定是否存在偏移
                                if (resource.ContainsKey("x"))
                                {
                                    resource["x"] = (int)resource["x"] + xadd;
                                }
                                if (resource.ContainsKey("y"))
                                {
                                    resource["y"] = (int)resource["y"] + yadd;
                                }
                                if (!resource.ContainsKey("x"))
                                {
                                    resource.Property("ah").AddAfterSelf(new JProperty("x", xadd));
                                }
                                if (!resource.ContainsKey("y"))
                                {
                                    resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                }
                            }
                            else if (resource["id"].ToString().Contains("_LEVEL_TAB_") && selected == "8")
                            {
                                //判定是否存在偏移
                                if (resource.ContainsKey("x"))
                                {
                                    resource["x"] = (int)resource["x"] + xadd;
                                }
                                if (resource.ContainsKey("y"))
                                {
                                    resource["y"] = (int)resource["y"] + yadd;
                                }
                                if (!resource.ContainsKey("x"))
                                {
                                    resource.Property("ah").AddAfterSelf(new JProperty("x", xadd));
                                }
                                if (!resource.ContainsKey("y"))
                                {
                                    resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                }
                            }
                            else if (resource["id"].ToString().Contains("_LOCK_SMALL") && selected == "9")
                            {
                                //判定是否存在偏移
                                if (resource.ContainsKey("x"))
                                {
                                    resource["x"] = (int)resource["x"] + xadd;
                                }
                                if (resource.ContainsKey("y"))
                                {
                                    resource["y"] = (int)resource["y"] + yadd;
                                }
                                if (!resource.ContainsKey("x"))
                                {
                                    resource.Property("ah").AddAfterSelf(new JProperty("x", xadd));
                                }
                                if (!resource.ContainsKey("y"))
                                {
                                    resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                }
                            }
                            else if (resource["id"].ToString().Contains("_LOCKED") && selected == "10")
                            {
                                //判定是否存在偏移
                                if (resource.ContainsKey("x"))
                                {
                                    resource["x"] = (int)resource["x"] + xadd;
                                }
                                if (resource.ContainsKey("y"))
                                {
                                    resource["y"] = (int)resource["y"] + yadd;
                                }
                                if (!resource.ContainsKey("x"))
                                {
                                    resource.Property("ah").AddAfterSelf(new JProperty("x", xadd));
                                }
                                if (!resource.ContainsKey("y"))
                                {
                                    resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                }
                            }
                            else if (resource["id"].ToString().Contains("MINTFAM_BANNER") && selected == "11")
                            {
                                //判定是否存在偏移
                                if (resource.ContainsKey("x"))
                                {
                                    resource["x"] = (int)resource["x"] + xadd;
                                }
                                if (resource.ContainsKey("y"))
                                {
                                    resource["y"] = (int)resource["y"] + yadd;
                                }
                                if (!resource.ContainsKey("x"))
                                {
                                    resource.Property("ah").AddAfterSelf(new JProperty("x", xadd));
                                }
                                if (!resource.ContainsKey("y"))
                                {
                                    resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                }
                            }
                            else if (resource["id"].ToString().Contains("_MINTFAM_") && selected == "12")
                            {
                                //判定是否存在偏移
                                if (resource.ContainsKey("x"))
                                {
                                    resource["x"] = (int)resource["x"] + xadd;
                                }
                                if (resource.ContainsKey("y"))
                                {
                                    resource["y"] = (int)resource["y"] + yadd;
                                }
                                if (!resource.ContainsKey("x"))
                                {
                                    resource.Property("ah").AddAfterSelf(new JProperty("x", xadd));
                                }
                                if (!resource.ContainsKey("y"))
                                {
                                    resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                }
                            }
                            else if (resource["id"].ToString().Contains("_POWERTILE_") && selected == "13")
                            {
                                //判定是否存在偏移
                                if (resource.ContainsKey("x"))
                                {
                                    resource["x"] = (int)resource["x"] + xadd;
                                }
                                if (resource.ContainsKey("y"))
                                {
                                    resource["y"] = (int)resource["y"] + yadd;
                                }
                                if (!resource.ContainsKey("x"))
                                {
                                    resource.Property("ah").AddAfterSelf(new JProperty("x", xadd));
                                }
                                if (!resource.ContainsKey("y"))
                                {
                                    resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                }
                            }
                            else if (resource["id"].ToString() == "IMAGE_UI_PACKETS_TOOLS_TOP" && selected == "14")
                            {
                                //判定是否存在偏移
                                if (resource.ContainsKey("x"))
                                {
                                    resource["x"] = (int)resource["x"] + xadd;
                                }
                                if (resource.ContainsKey("y"))
                                {
                                    resource["y"] = (int)resource["y"] + yadd;
                                }
                                if (!resource.ContainsKey("x"))
                                {
                                    resource.Property("ah").AddAfterSelf(new JProperty("x", xadd));
                                }
                                if (!resource.ContainsKey("y"))
                                {
                                    resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                }
                            }
                            else if (resource["id"].ToString().Contains("IMAGE_UI_STOREMULTI_") && selected == "15")
                            {
                                //判定是否存在偏移
                                if (resource.ContainsKey("x"))
                                {
                                    resource["x"] = (int)resource["x"] + xadd;
                                }
                                if (resource.ContainsKey("y"))
                                {
                                    resource["y"] = (int)resource["y"] + yadd;
                                }
                                if (!resource.ContainsKey("x"))
                                {
                                    resource.Property("ah").AddAfterSelf(new JProperty("x", xadd));
                                }
                                if (!resource.ContainsKey("y"))
                                {
                                    resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                }
                            }
                            else if (selected == "2")
                            {
                                if (int.Parse((string)resource["aw"]) == 238 && !resource["id"].ToString().Contains("IMAGE_UI_PACKETS_TOOLS_PROJECTILE_BOWLINGBULB")) { }
                                else if (int.Parse((string)resource["aw"]) == 239 && !resource["id"].ToString().Contains("IMAGE_UI_PACKETS_TOOLS_PROJECTILE_BOWLINGBULB")) { }
                                else if (int.Parse((string)resource["ah"]) == 150) { }
                                else if (int.Parse((string)resource["ah"]) == 151) { }
                                else if (resource["id"].ToString() == "IMAGE_UI_PACKETS_COOLDOWN") { }
                                else if (resource["id"].ToString() == "IMAGE_UI_PACKETS_SELECT") { }
                                else if (resource["id"].ToString().Contains("_PRICE_TAB")) { }
                                else if (resource["id"].ToString().Contains("_DOTS_")) { }
                                else if (resource["id"].ToString().Contains("_ICON")) { }
                                else if (resource["id"].ToString().Contains("_LEVEL_TAB_")) { }
                                else if (resource["id"].ToString().Contains("_LOCK_SMALL")) { }
                                else if (resource["id"].ToString().Contains("_LOCKED")) { }
                                else if (resource["id"].ToString().Contains("MINTFAM_BANNER")) { }
                                else if (resource["id"].ToString().Contains("_MINTFAM_")) { }
                                else if (resource["id"].ToString().Contains("_POWERTILE_")) { }
                                else if (resource["id"].ToString() == "IMAGE_UI_PACKETS_TOOLS_TOP") { }
                                else if (resource["id"].ToString().Contains("IMAGE_UI_STOREMULTI_")) { }
                                else
                                {
                                    //判定是否存在偏移
                                    if (resource.ContainsKey("x"))
                                    {
                                        resource["x"] = (int)resource["x"] + xadd;
                                    }
                                    if (resource.ContainsKey("y"))
                                    {
                                        resource["y"] = (int)resource["y"] + yadd;
                                    }
                                    if (!resource.ContainsKey("x"))
                                    {
                                        resource.Property("ah").AddAfterSelf(new JProperty("x", xadd));
                                    }
                                    if (!resource.ContainsKey("y"))
                                    {
                                        resource.Property("x").AddAfterSelf(new JProperty("y", yadd));
                                    }
                                }
                            }
                            else { }
                        }
                    }
                    Console.WriteLine("本次计算完成");
                    rss["resources"] = resources;
                    OffsetAdjust(rss);
                }
            }
            else { }
        }
        catch
        {
            Console.WriteLine("OffsetAdjust ERROR!");
            //提示按任意键继续
            Console.WriteLine("Press any key to continue...");
            //输入任意键退出
            Console.ReadLine();
        }
        return rss;
    }
}