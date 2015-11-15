using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.Misc.EntityFramework
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
 //         public static SortedList<string, string> GetTableKEY()
 //         {
 //             SortedList<string, string> list = new SortedList<string, string>();
 //             using (testEntities context = new testEntities())
 // 23:              {
 // 24:                  var entities = context.MetadataWorkspace.GetItems<EntityType>(DataSpace.CSpace);
 // 25:                  foreach (var item in entities)
 // 26:                  {
 // 27:                      foreach (var prop in item.Members)
 // 28:                      {
 // 29:                          var entityItem = item as EntityType;
 // 30:                          if (entityItem.KeyMembers.Any(p => p.Name == prop.Name))
 // 31:                          {
 // 32:                              list.Add(item.Name, prop.Name);
 // 33:                          }
 // 34:                      }
 // 35:                  }
 // 36:              }
 // 37:              return list;
 // 38:          }
 // 39:          /// <summary>
 // 40:          /// 获取表的关系
 // 41:          /// </summary>
 // 42:          /// <param name="tablename"></param>
 // 43:          /// <param name="IsRelation"></param>
 // 44:          /// <returns></returns>
 // 45:          public static List<TableRelation> GetTable(string tablename, bool IsRelation)
 // 46:          {
 // 47:              List<TableRelation> list = new List<TableRelation>();
 // 48:              using (testEntities context = new testEntities())
 // 49:              {
 // 50:                  var entities = context.MetadataWorkspace.GetItems<EntityType>(DataSpace.CSpace);
 // 51:                  EntityType entityItem = null;
 // 52:                  if (IsRelation)
 // 53:                  {
 // 54:                      foreach (var item in entities)
 // 55:                      {
 // 56:                          if (entityItem == null)
 // 57:                          {
 // 58:                              entityItem = item as EntityType;
 // 59:                          }
 // 60:                          if (entityItem.NavigationProperties.Contains(item.Name) || item.Name.Equals(tablename))
 // 61:                              list.Add(WriteProperties(item, context, DataSpace.CSpace));
 // 62:                      }
 // 63:                  }
 // 64:                  else
 // 65:                  {
 // 66:                      foreach (var item in entities)
 // 67:                      {
 // 68:                          if (entityItem == null)
 // 69:                          {
 // 70:                              entityItem = item as EntityType;
 // 71:                          }
 // 72:                          if (item.Name.Equals(tablename))
 // 73:                              list.Add(WriteProperties(item, context, DataSpace.CSpace));
 // 74:                      }
 // 75:                  }
 // 76:              }
 // 77:              return list;
 // 78:          }
 // 79:          /// <summary>
 // 80:          /// 表的关系合集
 // 81:          /// </summary>
 // 82:          /// <param name="item"></param>
 // 83:          /// <param name="ctx"></param>
 // 84:          /// <param name="space"></param>
 // 85:          /// <returns></returns>
 // 86:          public static TableRelation WriteProperties(StructuralType item, testEntities ctx, DataSpace space)
 // 87:          {
 // 88:              TableRelation tr = new TableRelation();
 // 89:              var node = (space == DataSpace.CSpace) ? "Properties" : "Columns";
 // 90:              List<Column> list = new List<Column>(); 
 // 91:   
 // 92:              foreach (var prop in item.Members)
 // 93:              {
 // 94:                  var entityItem = item as EntityType;
 // 95:                  Column column = new Column(); 
 // 96:   
 // 97:                  if (entityItem != null && entityItem.Properties.Contains(prop))
 // 98:                  {
 // 99:                      column.columnname = prop.Name;
 //100:                      column.title = prop.Documentation != null ? prop.Documentation.Summary : null;
 //101:                      column.type = prop.TypeUsage.EdmType != null ? prop.TypeUsage.EdmType.Name : null;
 //102:                      column.maxlength = prop.TypeUsage.Facets.Contains("MaxLength") ? prop.TypeUsage.Facets["MaxLength"].Value.ToString() : null;
 //103:                      if (ctx.MetadataWorkspace
 //104:                        .GetItems<AssociationType>(space)
 //105:                          .Where(a => a.IsForeignKey).Any(a =>
 //106:                            a.ReferentialConstraints[0]
 //107:                             .ToProperties[0].Name == prop.Name &&
 //108:                            a.ReferentialConstraints[0].ToRole.Name.Contains(item.Name)))
 //109:                      {
 //110:                          for (int i = 0; i < Realation(item, ctx, DataSpace.CSpace).Count; i++)
 //111:                          {
 //112:                              if (Realation(item, ctx, DataSpace.CSpace).Values[i].Values[0].Equals(prop.Name) &&
 //113:                                 Realation(item, ctx, DataSpace.CSpace).Values[i].Values[2].Contains(item.Name))
 //114:                              { 
 //115:   
 //116:                                  column.mainrole = Realation(item, ctx, DataSpace.CSpace).Values[i].Values[6].ToString();
 //117:                                  column.mainmultiplicity = Realation(item, ctx, DataSpace.CSpace).Values[i].Values[5].ToString();
 //118:                                  column.mainkey = Realation(item, ctx, DataSpace.CSpace).Values[i].Values[4].ToString();
 //119:                                  column.relationname = Realation(item, ctx, DataSpace.CSpace).Values[i].Values[3].ToString(); 
 //120:   
 //121:                              } 
 //122:   
 //123:                          }
 //124:                      }
 //125:                      list.Add(column);
 //126:                  }
 //127:                  tr.tablename = item.Name;
 //128:                  tr.tabletitle = item.Documentation != null ? item.Documentation.Summary : item.Name;
 //129:                  tr.columns = list;
 //130:              }
 //131:              return tr;
 //132:          }
 //133:          /// <summary>
 //134:          /// 返回所有主表的关系
 //135:          /// </summary>
 //136:          /// <param name="item"></param>
 //137:          /// <param name="ctx"></param>
 //138:          /// <param name="space"></param>
 //139:          /// <returns></returns>
 //140:          public static SortedList<string, SortedList<string, string>> Realation(StructuralType item, testEntities ctx, DataSpace space)
 //141:          {
 //142:              SortedList<string, SortedList<string, string>> list1 = new SortedList<string, SortedList<string, string>>();
 //143:              var entity = ctx.MetadataWorkspace.GetItems<AssociationType>(space);
 //144:              foreach (var a in entity)
 //145:              {
 //146:                  var entityItem = item as EntityType;
 //147:                  for (int i = 0; i < entityItem.NavigationProperties.Count; i++)
 //148:                  {
 //149:                      if (entityItem.NavigationProperties[i].RelationshipType.Name.Equals(a.Name))
 //150:                      {
 //151:                          SortedList<string, string> list = new SortedList<string, string>();
 //152:                          list.Add("mainrole", a.ReferentialConstraints[0].ToRole.Name);
 //153:                          list.Add("mainkey", a.ReferentialConstraints[0].ToProperties[0].Name);
 //154:                          list.Add("mainmultiplicity", a.ReferentialConstraints[0].ToRole.RelationshipMultiplicity.ToString());
 //155:                          list.Add("subrole", a.ReferentialConstraints[0].FromRole.Name);
 //156:                          list.Add("subkey", a.ReferentialConstraints[0].FromProperties[0].Name);
 //157:                          list.Add("submultiplicity", a.ReferentialConstraints[0].FromRole.RelationshipMultiplicity.ToString());
 //158:                          list.Add("relationname", a.Name);
 //159:                          if (!list1.ContainsKey(a.Name))
 //160:                          {
 //161:                              list1.Add(a.Name, list);
 //162:                          }
 //163:                      }
 //164:                  }
 //165:              }
 //166:              return list1;
 //167:          }

       }
    }
}
