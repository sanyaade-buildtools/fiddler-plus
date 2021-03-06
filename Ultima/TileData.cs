using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Ultima
{
    /// <summary>
    /// Represents land tile data.
    /// <seealso cref="ItemData" />
    /// <seealso cref="LandData" />
    /// </summary>
    public struct LandData
    {
        private string m_Name;
        private short m_TexID;
        private TileFlag m_Flags;

        public LandData(string name, int TexID, TileFlag flags)
        {
            m_Name = name;
            m_TexID = (short)TexID;
            m_Flags = flags;
        }

        public unsafe LandData(LandTileOldDataMul oldmulstruct)
        {
            m_TexID = oldmulstruct.texID;
            m_Flags = (TileFlag)oldmulstruct.flags;
            m_Name = TileData.ReadNameString(oldmulstruct.name);
        }

        public unsafe LandData(LandTileDataMul mulstruct)
        {
            m_TexID = mulstruct.texID;
            m_Flags = (TileFlag)mulstruct.flags;
            m_Name = TileData.ReadNameString(mulstruct.name);
        }

        /// <summary>
        /// Gets the name of this land tile.
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        /// <summary>
        /// Gets the Texture ID of this land tile.
        /// </summary>
        public short TextureID
        {
            get { return m_TexID; }
            set { m_TexID = value; }
        }

        /// <summary>
        /// Gets a bitfield representing the 32 individual flags of this land tile.
        /// </summary>
        public TileFlag Flags
        {
            get { return m_Flags; }
            set { m_Flags = value; }
        }

        public void ReadData(string[] split)
        {
            m_Name = split[1];
            m_TexID = (short)TileData.ConvertStringToInt(split[2]);

            m_Flags = (TileFlag)((long)m_Flags & unchecked((long)0xFFFFFFFF00000000));
            //m_Flags = 0;
            int temp = System.Convert.ToByte(split[3]);
            if (temp != 0)
                m_Flags |= TileFlag.Background;
            temp = System.Convert.ToByte(split[4]);
            if (temp != 0)
                m_Flags |= TileFlag.Weapon;
            temp = System.Convert.ToByte(split[5]);
            if (temp != 0)
                m_Flags |= TileFlag.Transparent;
            temp = System.Convert.ToByte(split[6]);
            if (temp != 0)
                m_Flags |= TileFlag.Translucent;
            temp = System.Convert.ToByte(split[7]);
            if (temp != 0)
                m_Flags |= TileFlag.Wall;
            temp = System.Convert.ToByte(split[8]);
            if (temp != 0)
                m_Flags |= TileFlag.Damaging;
            temp = System.Convert.ToByte(split[9]);
            if (temp != 0)
                m_Flags |= TileFlag.Impassable;
            temp = System.Convert.ToByte(split[10]);
            if (temp != 0)
                m_Flags |= TileFlag.Wet;
            temp = System.Convert.ToByte(split[11]);
            if (temp != 0)
                m_Flags |= TileFlag.Unknown1;
            temp = System.Convert.ToByte(split[12]);
            if (temp != 0)
                m_Flags |= TileFlag.Surface;
            temp = System.Convert.ToByte(split[13]);
            if (temp != 0)
                m_Flags |= TileFlag.Bridge;
            temp = System.Convert.ToByte(split[14]);
            if (temp != 0)
                m_Flags |= TileFlag.Generic;
            temp = System.Convert.ToByte(split[15]);
            if (temp != 0)
                m_Flags |= TileFlag.Window;
            temp = System.Convert.ToByte(split[16]);
            if (temp != 0)
                m_Flags |= TileFlag.NoShoot;
            temp = System.Convert.ToByte(split[17]);
            if (temp != 0)
                m_Flags |= TileFlag.ArticleA;
            temp = System.Convert.ToByte(split[18]);
            if (temp != 0)
                m_Flags |= TileFlag.ArticleAn;
            temp = System.Convert.ToByte(split[19]);
            if (temp != 0)
                m_Flags |= TileFlag.Internal;
            temp = System.Convert.ToByte(split[20]);
            if (temp != 0)
                m_Flags |= TileFlag.Foliage;
            temp = System.Convert.ToByte(split[21]);
            if (temp != 0)
                m_Flags |= TileFlag.PartialHue;
            temp = System.Convert.ToByte(split[22]);
            if (temp != 0)
                m_Flags |= TileFlag.Unknown2;
            temp = System.Convert.ToByte(split[23]);
            if (temp != 0)
                m_Flags |= TileFlag.Map;
            temp = System.Convert.ToByte(split[24]);
            if (temp != 0)
                m_Flags |= TileFlag.Container;
            temp = System.Convert.ToByte(split[25]);
            if (temp != 0)
                m_Flags |= TileFlag.Wearable;
            temp = System.Convert.ToByte(split[26]);
            if (temp != 0)
                m_Flags |= TileFlag.LightSource;
            temp = System.Convert.ToByte(split[27]);
            if (temp != 0)
                m_Flags |= TileFlag.Animation;
            temp = System.Convert.ToByte(split[28]);
            if (temp != 0)
                m_Flags |= TileFlag.HoverOver;
            temp = System.Convert.ToByte(split[29]);
            if (temp != 0)
                m_Flags |= TileFlag.Unknown3;
            temp = System.Convert.ToByte(split[30]);
            if (temp != 0)
                m_Flags |= TileFlag.Armor;
            temp = System.Convert.ToByte(split[31]);
            if (temp != 0)
                m_Flags |= TileFlag.Roof;
            temp = System.Convert.ToByte(split[32]);
            if (temp != 0)
                m_Flags |= TileFlag.Door;
            temp = System.Convert.ToByte(split[33]);
            if (temp != 0)
                m_Flags |= TileFlag.StairBack;
            temp = System.Convert.ToByte(split[34]);
            if (temp != 0)
                m_Flags |= TileFlag.StairRight;
        }
    }

    /// <summary>
    /// Represents item tile data.
    /// <seealso cref="TileData" />
    /// <seealso cref="LandData" />
    /// </summary>
    public struct ItemData
    {
        internal string m_Name;
        internal TileFlag m_Flags;
        internal byte m_Weight;
        internal byte m_Quality;
        internal byte m_Quantity;
        internal byte m_Value;
        internal byte m_Height;
        internal short m_Animation;
        internal byte m_Hue;
        internal byte m_StackOffset;
        internal short m_MiscData;
        internal byte m_Unk2;
        internal byte m_Unk3;

        public ItemData(string name, TileFlag flags, int weight, int quality, int quantity, int value, int height, int anim, int hue, int stackingoffset, int MiscData, int unk2, int unk3)
        {
            m_Name = name;
            m_Flags = flags;
            m_Weight = (byte)weight;
            m_Quality = (byte)quality;
            m_Quantity = (byte)quantity;
            m_Value = (byte)value;
            m_Height = (byte)height;
            m_Animation = (short)anim;
            m_Hue = (byte)hue;
            m_StackOffset = (byte)stackingoffset;
            m_MiscData = (short)MiscData;
            m_Unk2 = (byte)unk2;
            m_Unk3 = (byte)unk3;
        }

        public unsafe ItemData(ItemTileOldDataMul oldmulstruct)
        {
            m_Name = TileData.ReadNameString(oldmulstruct.name);
            m_Flags = (TileFlag)oldmulstruct.flags;
            m_Weight = oldmulstruct.weight;
            m_Quality = oldmulstruct.quality;
            m_Quantity = oldmulstruct.quantity;
            m_Value = oldmulstruct.value;
            m_Height = oldmulstruct.height;
            m_Animation = oldmulstruct.anim;
            m_Hue = oldmulstruct.hue;
            m_StackOffset = oldmulstruct.stackingoffset;
            m_MiscData = oldmulstruct.miscdata;
            m_Unk2 = oldmulstruct.unk2;
            m_Unk3 = oldmulstruct.unk3;
        }

        public unsafe ItemData(ItemTileDataMul mulstruct)
        {
            m_Name = TileData.ReadNameString(mulstruct.name);
            m_Flags = (TileFlag)mulstruct.flags;
            m_Weight = mulstruct.weight;
            m_Quality = mulstruct.quality;
            m_Quantity = mulstruct.quantity;
            m_Value = mulstruct.value;
            m_Height = mulstruct.height;
            m_Animation = mulstruct.anim;
            m_Hue = mulstruct.hue;
            m_StackOffset = mulstruct.stackingoffset;
            m_MiscData = mulstruct.miscdata;
            m_Unk2 = mulstruct.unk2;
            m_Unk3 = mulstruct.unk3;
        }

        /// <summary>
        /// Gets the name of this item.
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        /// <summary>
        /// Gets the animation body index of this item.
        /// <seealso cref="Animations" />
        /// </summary>
        public short Animation
        {
            get { return m_Animation; }
            set { m_Animation = value; }
        }

        /// <summary>
        /// Gets a bitfield representing the 32 individual flags of this item.
        /// <seealso cref="TileFlag" />
        /// </summary>
        public TileFlag Flags
        {
            get { return m_Flags; }
            set { m_Flags = value; }
        }

        /// <summary>
        /// Whether or not this item is flagged as '<see cref="TileFlag.Background" />'.
        /// <seealso cref="TileFlag" />
        /// </summary>
        public bool Background
        {
            get { return ((m_Flags & TileFlag.Background) != 0); }
        }

        /// <summary>
        /// Whether or not this item is flagged as '<see cref="TileFlag.Bridge" />'.
        /// <seealso cref="TileFlag" />
        /// </summary>
        public bool Bridge
        {
            get { return ((m_Flags & TileFlag.Bridge) != 0); }
        }

        /// <summary>
        /// Whether or not this item is flagged as '<see cref="TileFlag.Impassable" />'.
        /// <seealso cref="TileFlag" />
        /// </summary>
        public bool Impassable
        {
            get { return ((m_Flags & TileFlag.Impassable) != 0); }
        }

        /// <summary>
        /// Whether or not this item is flagged as '<see cref="TileFlag.Surface" />'.
        /// <seealso cref="TileFlag" />
        /// </summary>
        public bool Surface
        {
            get { return ((m_Flags & TileFlag.Surface) != 0); }
        }

        /// <summary>
        /// Gets the weight of this item.
        /// </summary>
        public byte Weight
        {
            get { return m_Weight; }
            set { m_Weight = value; }
        }

        /// <summary>
        /// Gets the 'quality' of this item. For wearable items, this will be the layer.
        /// </summary>
        public byte Quality
        {
            get { return m_Quality; }
            set { m_Quality = value; }
        }

        /// <summary>
        /// Gets the 'quantity' of this item.
        /// </summary>
        public byte Quantity
        {
            get { return m_Quantity; }
            set { m_Quantity = value; }
        }

        /// <summary>
        /// Gets the 'value' of this item.
        /// </summary>
        public byte Value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }

        /// <summary>
        /// Gets the Hue of this item.
        /// </summary>
        public byte Hue
        {
            get { return m_Hue; }
            set { m_Hue = value; }
        }

        /// <summary>
        /// Gets the stackingoffset of this item. (If flag Generic)
        /// </summary>
        public byte StackingOffset
        {
            get { return m_StackOffset; }
            set { m_StackOffset = value; }
        }

        /// <summary>
        /// Gets the height of this item.
        /// </summary>
        public byte Height
        {
            get { return m_Height; }
            set { m_Height = value; }
        }

        /// <summary>
        /// Gets the MiscData of this item. (old UO Demo weapontemplate definition) (Unk1)
        /// </summary>
        public short MiscData
        {
            get { return m_MiscData; }
            set { m_MiscData = value; }
        }

        /// <summary>
        /// Gets the unk2 of this item.
        /// </summary>
        public byte Unk2
        {
            get { return m_Unk2; }
            set { m_Unk2 = value; }
        }

        /// <summary>
        /// Gets the unk3 of this item.
        /// </summary>
        public byte Unk3
        {
            get { return m_Unk3; }
            set { m_Unk3 = value; }
        }

        /// <summary>
        /// Gets the 'calculated height' of this item. For <see cref="Bridge">bridges</see>, this will be: <c>(<see cref="Height" /> / 2)</c>.
        /// </summary>
        public int CalcHeight
        {
            get
            {
                if ((m_Flags & TileFlag.Bridge) != 0)
                    return m_Height / 2;
                else
                    return m_Height;
            }
        }

        /// <summary>
        /// Whether or not this item is wearable as '<see cref="TileFlag.Wearable" />'.
        /// <seealso cref="TileFlag" />
        /// </summary>
        public bool Wearable
        {
            get { return ((m_Flags & TileFlag.Wearable) != 0); }
        }

        public void ReadData(string[] split)
        {
            m_Name = String.IsNullOrEmpty(split[1]) ? m_Name : split[1];
            m_Weight = System.Convert.ToByte(split[2]);
            m_Quality = System.Convert.ToByte(split[3]);
            m_Animation = (short)TileData.ConvertStringToInt(split[4]);
            m_Height = System.Convert.ToByte(split[5]);
            m_Hue = System.Convert.ToByte(split[6]);
            m_Quantity = System.Convert.ToByte(split[7]);
            m_StackOffset = System.Convert.ToByte(split[8]);
            m_MiscData = System.Convert.ToInt16(split[9]);
            m_Unk2 = System.Convert.ToByte(split[10]);
            m_Unk3 = System.Convert.ToByte(split[11]);

            //m_Flags = 0;
            int temp = System.Convert.ToByte(split[12]);
            if (temp != 0)
                m_Flags |= TileFlag.Background;
            temp = System.Convert.ToByte(split[13]);
            if (temp != 0)
                m_Flags |= TileFlag.Weapon;
            temp = System.Convert.ToByte(split[14]);
            if (temp != 0)
                m_Flags |= TileFlag.Transparent;
            temp = System.Convert.ToByte(split[15]);
            if (temp != 0)
                m_Flags |= TileFlag.Translucent;
            temp = System.Convert.ToByte(split[16]);
            if (temp != 0)
                m_Flags |= TileFlag.Wall;
            temp = System.Convert.ToByte(split[17]);
            if (temp != 0)
                m_Flags |= TileFlag.Damaging;
            temp = System.Convert.ToByte(split[18]);
            if (temp != 0)
                m_Flags |= TileFlag.Impassable;
            temp = System.Convert.ToByte(split[19]);
            if (temp != 0)
                m_Flags |= TileFlag.Wet;
            temp = System.Convert.ToByte(split[20]);
            if (temp != 0)
                m_Flags |= TileFlag.Unknown1;
            temp = System.Convert.ToByte(split[21]);
            if (temp != 0)
                m_Flags |= TileFlag.Surface;
            temp = System.Convert.ToByte(split[22]);
            if (temp != 0)
                m_Flags |= TileFlag.Bridge;
            temp = System.Convert.ToByte(split[23]);
            if (temp != 0)
                m_Flags |= TileFlag.Generic;
            temp = System.Convert.ToByte(split[24]);
            if (temp != 0)
                m_Flags |= TileFlag.Window;
            temp = System.Convert.ToByte(split[25]);
            if (temp != 0)
                m_Flags |= TileFlag.NoShoot;
            temp = System.Convert.ToByte(split[26]);
            if (temp != 0)
                m_Flags |= TileFlag.ArticleA;
            temp = System.Convert.ToByte(split[27]);
            if (temp != 0)
                m_Flags |= TileFlag.ArticleAn;
            temp = System.Convert.ToByte(split[28]);
            if (temp != 0)
                m_Flags |= TileFlag.Internal;
            temp = System.Convert.ToByte(split[29]);
            if (temp != 0)
                m_Flags |= TileFlag.Foliage;
            temp = System.Convert.ToByte(split[30]);
            if (temp != 0)
                m_Flags |= TileFlag.PartialHue;
            temp = System.Convert.ToByte(split[31]);
            if (temp != 0)
                m_Flags |= TileFlag.Unknown2;
            temp = System.Convert.ToByte(split[32]);
            if (temp != 0)
                m_Flags |= TileFlag.Map;
            temp = System.Convert.ToByte(split[33]);
            if (temp != 0)
                m_Flags |= TileFlag.Container;
            temp = System.Convert.ToByte(split[34]);
            if (temp != 0)
                m_Flags |= TileFlag.Wearable;
            temp = System.Convert.ToByte(split[35]);
            if (temp != 0)
                m_Flags |= TileFlag.LightSource;
            temp = System.Convert.ToByte(split[36]);
            if (temp != 0)
                m_Flags |= TileFlag.Animation;
            temp = System.Convert.ToByte(split[37]);
            if (temp != 0)
                m_Flags |= TileFlag.HoverOver;
            temp = System.Convert.ToByte(split[38]);
            if (temp != 0)
                m_Flags |= TileFlag.Unknown3;
            temp = System.Convert.ToByte(split[39]);
            if (temp != 0)
                m_Flags |= TileFlag.Armor;
            temp = System.Convert.ToByte(split[40]);
            if (temp != 0)
                m_Flags |= TileFlag.Roof;
            temp = System.Convert.ToByte(split[41]);
            if (temp != 0)
                m_Flags |= TileFlag.Door;
            temp = System.Convert.ToByte(split[42]);
            if (temp != 0)
                m_Flags |= TileFlag.StairBack;
            temp = System.Convert.ToByte(split[43]);
            if (temp != 0)
                m_Flags |= TileFlag.StairRight;
        }
    }

    /// <summary>
    /// An enumeration of 32 different tile flags.
    /// <seealso cref="ItemData" />
    /// <seealso cref="LandData" />
    /// </summary>
    [Flags]
    public enum TileFlag : long
    {
        /// <summary>
        /// Nothing is flagged.
        /// </summary>
        None            = 0x0000000000000000,
        /// <summary>
        /// Not yet documented.
        /// </summary>
        Background      = 0x0000000000000001,
        /// <summary>
        /// Not yet documented.
        /// </summary>
        Weapon          = 0x0000000000000002,
        /// <summary>
        /// Not yet documented.
        /// </summary>
        Transparent     = 0x0000000000000004,
        /// <summary>
        /// The tile is rendered with partial alpha-transparency.
        /// </summary>
        Translucent     = 0x0000000000000008,
        /// <summary>
        /// The tile is a wall.
        /// </summary>
        Wall            = 0x0000000000000010,
        /// <summary>
        /// The tile can cause damage when moved over.
        /// </summary>
        Damaging        = 0x0000000000000020,
        /// <summary>
        /// The tile may not be moved over or through.
        /// </summary>
        Impassable      = 0x0000000000000040,
        /// <summary>
        /// Not yet documented.
        /// </summary>
        Wet             = 0x0000000000000080,
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown1        = 0x0000000000000100,
        /// <summary>
        /// The tile is a surface. It may be moved over, but not through.
        /// </summary>
        Surface         = 0x0000000000000200,
        /// <summary>
        /// The tile is a stair, ramp, or ladder.
        /// </summary>
        Bridge          = 0x0000000000000400,
        /// <summary>
        /// The tile is stackable
        /// </summary>
        Generic         = 0x0000000000000800,
        /// <summary>
        /// The tile is a window. Like <see cref="TileFlag.NoShoot" />, tiles with this flag block line of sight.
        /// </summary>
        Window          = 0x0000000000001000,
        /// <summary>
        /// The tile blocks line of sight.
        /// </summary>
        NoShoot         = 0x0000000000002000,
        /// <summary>
        /// For single-amount tiles, the string "a " should be prepended to the tile name.
        /// </summary>
        ArticleA        = 0x0000000000004000,
        /// <summary>
        /// For single-amount tiles, the string "an " should be prepended to the tile name.
        /// </summary>
        ArticleAn       = 0x0000000000008000,
        /// <summary>
        /// Not yet documented.
        /// </summary>
        Internal        = 0x0000000000010000,
        /// <summary>
        /// The tile becomes translucent when walked behind. Boat masts also have this flag.
        /// </summary>
        Foliage         = 0x0000000000020000,
        /// <summary>
        /// Only gray pixels will be hued
        /// </summary>
        PartialHue      = 0x0000000000040000,
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown2        = 0x0000000000080000,
        /// <summary>
        /// The tile is a map--in the cartography sense. Unknown usage.
        /// </summary>
        Map             = 0x0000000000100000,
        /// <summary>
        /// The tile is a container.
        /// </summary>
        Container       = 0x0000000000200000,
        /// <summary>
        /// The tile may be equiped.
        /// </summary>
        Wearable        = 0x0000000000400000,
        /// <summary>
        /// The tile gives off light.
        /// </summary>
        LightSource     = 0x0000000000800000,
        /// <summary>
        /// The tile is animated.
        /// </summary>
        Animation       = 0x0000000001000000,
        /// <summary>
        /// Gargoyles can fly over
        /// </summary>
        HoverOver       = 0x0000000002000000,
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown3        = 0x0000000004000000,
        /// <summary>
        /// Not yet documented.
        /// </summary>
        Armor           = 0x0000000008000000,
        /// <summary>
        /// The tile is a slanted roof.
        /// </summary>
        Roof            = 0x0000000010000000,
        /// <summary>
        /// The tile is a door. Tiles with this flag can be moved through by ghosts and GMs.
        /// </summary>
        Door            = 0x0000000020000000,
        /// <summary>
        /// Not yet documented.
        /// </summary>
        StairBack       = 0x0000000040000000,
        /// <summary>
        /// Not yet documented.
        /// </summary>
        StairRight      = 0x0000000080000000,
        UnUsed01        = 0x0000000100000000,
        /// <summary>
        /// ����� ��� ������� �����
        /// </summary>
        Unknown4        = 0x0000000200000000,
        UnUsed03        = 0x0000000400000000,
        /// <summary>
        /// 
        /// </summary>
        Unknown5        = 0x0000000800000000,
        /// <summary>
        /// 
        /// </summary>
        Unknown6        = 0x0000001000000000,
        /// <summary>
        /// 
        /// </summary>
        Unknown7        = 0x0000002000000000,
        UnUsed07        = 0x0000004000000000,

        UnUsed08        = 0x0000008000000000,
        /// <summary>
        /// ����� �������� � �������
        /// </summary>
        Unknown8        = 0x0000010000000000,
        UnUsed10        = 0x0000020000000000,
        UnUsed11        = 0x0000040000000000,
        UnUsed12        = 0x0000080000000000,
        UnUsed13        = 0x0000100000000000,
        UnUsed14        = 0x0000200000000000,
        UnUsed15        = 0x0000400000000000,
        UnUsed16        = 0x0000800000000000,
        UnUsed17        = 0x0001000000000000,
        UnUsed18        = 0x0002000000000000,
        UnUsed19        = 0x0004000000000000,
        UnUsed20        = 0x0008000000000000,
        UnUsed21        = 0x0010000000000000,
        UnUsed22        = 0x0020000000000000,
        UnUsed23        = 0x0040000000000000,
        UnUsed24        = 0x0080000000000000,
        UnUsed25        = 0x0100000000000000,
        UnUsed26        = 0x0200000000000000,
        UnUsed27        = 0x0400000000000000,
        UnUsed28        = 0x0800000000000000,
        UnUsed29        = 0x1000000000000000,
        UnUsed30        = 0x2000000000000000,
        UnUsed31        = 0x4000000000000000,
        UnUsed32        = unchecked((long)0x8000000000000000)
    }

    /// <summary>
    /// Contains lists of <see cref="LandData">land</see> and <see cref="ItemData">item</see> tile data.
    /// <seealso cref="LandData" />
    /// <seealso cref="ItemData" />
    /// </summary>
    public sealed class TileData
    {
        private static LandData[] m_LandData;
        private static ItemData[] m_ItemData;
        private static int[] m_HeightTable;

        /// <summary>
        /// Gets the list of <see cref="LandData">land tile data</see>.
        /// </summary>
        public static LandData[] LandTable
        {
            get { return m_LandData; }
            set { m_LandData = value; }
        }

        /// <summary>
        /// Gets the list of <see cref="ItemData">item tile data</see>.
        /// </summary>
        public static ItemData[] ItemTable
        {
            get { return m_ItemData; }
            set { m_ItemData = value; }
        }

        public static int[] HeightTable
        {
            get { return m_HeightTable; }
        }

        private static byte[] m_StringBuffer = new byte[20];
        private static string ReadNameString(BinaryReader bin)
        {
            bin.Read(m_StringBuffer, 0, 20);

            int count;

            for (count = 0; count < 20 && m_StringBuffer[count] != 0; ++count) ;

            return Encoding.GetEncoding(1251).GetString(m_StringBuffer, 0, count);
        }

        public unsafe static string ReadNameString(byte* buffer)
        {
            int count;
            for (count = 0; count < 20 && *buffer != 0; ++count)
                m_StringBuffer[count] = *buffer++;

            return Encoding.Default.GetString(m_StringBuffer, 0, count);
        }

        private TileData()
        {
        }

        private static int[] landheader;
        private static int[] itemheader;

        static TileData()
        {
            Initialize();
        }

        public unsafe static void Initialize()
        {
            string filePath = Files.GetFilePath("tiledata.mul");

            if (filePath != null)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    landheader = new int[512];
                    int j = 0;
                    m_LandData = new LandData[0x4000];

                    byte[] buffer = new byte[fs.Length];
                    GCHandle gc = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                    long currpos = 0;
                    try
                    {
                        fs.Read(buffer, 0, buffer.Length);
                        if (Ultima.Art.IsUOHS) // TileData ����� HS
                        {
                            for (int i = 0; i < 0x4000; i += 32)
                            {
                                IntPtr ptrheader = new IntPtr((long)gc.AddrOfPinnedObject() + currpos);
                                currpos += 4;
                                landheader[j++] = (int)Marshal.PtrToStructure(ptrheader, typeof(int));

                                for (int count = 0; count < 32; ++count)
                                {
                                    IntPtr ptr = new IntPtr((long)gc.AddrOfPinnedObject() + currpos);
                                    currpos += sizeof(LandTileDataMul);
                                    LandTileDataMul cur = (LandTileDataMul)Marshal.PtrToStructure(ptr, typeof(LandTileDataMul));
                                    m_LandData[i + count] = new LandData(cur);
                                }
                            }
                        }
                        else // TileData �� HS
                        {
                            for (int i = 0; i < 0x4000; i += 32)
                            {
                                IntPtr ptrheader = new IntPtr((long)gc.AddrOfPinnedObject() + currpos);
                                currpos += 4;
                                landheader[j++] = (int)Marshal.PtrToStructure(ptrheader, typeof(int));

                                for (int count = 0; count < 32; ++count)
                                {
                                    IntPtr ptr = new IntPtr((long)gc.AddrOfPinnedObject() + currpos);
                                    currpos += sizeof(LandTileOldDataMul);
                                    LandTileOldDataMul cur = (LandTileOldDataMul)Marshal.PtrToStructure(ptr, typeof(LandTileOldDataMul));
                                    m_LandData[i + count] = new LandData(cur);
                                }
                            }
                        }
                        

                        int remaining = (int)(buffer.Length - currpos);
                        int itemlength; // 32 ������ ������ 41/37 ���� � ����� � ������ 4 �����
                        itemlength = 32 * remaining / (4 + 32 * (Ultima.Art.IsUOHS ? 41 : 37));
                        itemheader = new int[itemlength / 32];
                        //itemlength = Math.Min(Art.StaticLength, itemlength);

                        m_ItemData = new ItemData[itemlength];
                        m_HeightTable = new int[itemlength];

                        j = 0;
                        if (Ultima.Art.IsUOHS) // TileData ����� HS
                        {
                            for (int i = 0; i < itemlength; i += 32)
                            {
                                IntPtr ptrheader = new IntPtr((long)gc.AddrOfPinnedObject() + currpos);
                                currpos += 4;
                                itemheader[j++] = (int)Marshal.PtrToStructure(ptrheader, typeof(int));
                                for (int count = 0; count < 32; ++count)
                                {
                                    IntPtr ptr = new IntPtr((long)gc.AddrOfPinnedObject() + currpos);
                                    currpos += sizeof(ItemTileDataMul);
                                    ItemTileDataMul cur = (ItemTileDataMul)Marshal.PtrToStructure(ptr, typeof(ItemTileDataMul));
                                    m_ItemData[i + count] = new ItemData(cur);
                                    m_HeightTable[i + count] = cur.height;
                                }
                            }
                        }
                        else // TileData �� HS
                        {
                            for (int i = 0; i < itemlength; i += 32)
                            {
                                IntPtr ptrheader = new IntPtr((long)gc.AddrOfPinnedObject() + currpos);
                                currpos += 4;
                                itemheader[j++] = (int)Marshal.PtrToStructure(ptrheader, typeof(int));
                                for (int count = 0; count < 32; ++count)
                                {
                                    IntPtr ptr = new IntPtr((long)gc.AddrOfPinnedObject() + currpos);
                                    currpos += sizeof(ItemTileOldDataMul);
                                    ItemTileOldDataMul cur = (ItemTileOldDataMul)Marshal.PtrToStructure(ptr, typeof(ItemTileOldDataMul));
                                    m_ItemData[i + count] = new ItemData(cur);
                                    m_HeightTable[i + count] = cur.height;
                                }
                            }
                        }
                        
                    }
                    finally
                    {
                        gc.Free();
                    }
                }
            }
        }

        /// <summary>
        /// Saves <see cref="LandData"/> and <see cref="ItemData"/> to tiledata.mul
        /// </summary>
        /// <param name="FileName"></param>
        public static void SaveTileData(string FileName)
        {
            using (FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                using (BinaryWriter bin = new BinaryWriter(fs))
                {
                    int j = 0;
                    if (m_ItemData.Length > 0xF000) // HS file format   
                        for (int i = 0; i < 0x4000; ++i)
                        {
                            if ((i & 0x1F) == 0)
                                bin.Write(landheader[j++]); //header
                            bin.Write((long)m_LandData[i].Flags);
                            bin.Write(m_LandData[i].TextureID);
                            byte[] b = new byte[20];
                            if (m_LandData[i].Name != null)
                            {
                                byte[] bb = Encoding.GetEncoding(1251).GetBytes(m_LandData[i].Name);
                                if (bb.Length > 20)
                                    Array.Resize(ref bb, 20);
                                bb.CopyTo(b, 0);
                            }
                            bin.Write(b);
                        }
                    else // SA and pre ML file format
                        for (int i = 0; i < 0x4000; ++i)
                        {
                            if ((i & 0x1F) == 0)
                                bin.Write(landheader[j++]); //header
                            bin.Write((int)m_LandData[i].Flags);
                            bin.Write(m_LandData[i].TextureID);
                            byte[] b = new byte[20];
                            if (m_LandData[i].Name != null)
                            {
                                byte[] bb = Encoding.GetEncoding(1251).GetBytes(m_LandData[i].Name);
                                if (bb.Length > 20)
                                    Array.Resize(ref bb, 20);
                                bb.CopyTo(b, 0);
                            }
                            bin.Write(b);
                        }

                    j = 0;
                    if (m_ItemData.Length > 0xF000) // HS file format
                        for (int i = 0; i < m_ItemData.Length; ++i)
                        {
                            if ((i & 0x1F) == 0)
                                bin.Write(itemheader[j++]); // header
                            bin.Write((long)m_ItemData[i].Flags);
                            //bin.Write((int)m_ItemData[i].NewFlags);
                            bin.Write(m_ItemData[i].Weight);
                            bin.Write(m_ItemData[i].Quality);
                            bin.Write(m_ItemData[i].MiscData);
                            bin.Write(m_ItemData[i].Unk2);
                            bin.Write(m_ItemData[i].Quantity);
                            bin.Write(m_ItemData[i].Animation);
                            bin.Write(m_ItemData[i].Unk3);
                            bin.Write(m_ItemData[i].Hue);
                            bin.Write(m_ItemData[i].StackingOffset); //unk4
                            bin.Write(m_ItemData[i].Value); //unk5
                            bin.Write(m_ItemData[i].Height);
                            byte[] b = new byte[20];
                            if (m_ItemData[i].Name != null)
                            {
                                byte[] bb = Encoding.GetEncoding(1251).GetBytes(m_ItemData[i].Name);
                                if (bb.Length > 20)
                                    Array.Resize(ref bb, 20);
                                bb.CopyTo(b, 0);
                            }
                            bin.Write(b);
                        }
                    else // SA and pre ML file format
                        for (int i = 0; i < m_ItemData.Length; ++i)
                        {
                            if ((i & 0x1F) == 0)
                                bin.Write(itemheader[j++]); // header
                            bin.Write((int)m_ItemData[i].Flags);
                            bin.Write(m_ItemData[i].Weight);
                            bin.Write(m_ItemData[i].Quality);
                            bin.Write(m_ItemData[i].MiscData);
                            bin.Write(m_ItemData[i].Unk2);
                            bin.Write(m_ItemData[i].Quantity);
                            bin.Write(m_ItemData[i].Animation);
                            bin.Write(m_ItemData[i].Unk3);
                            bin.Write(m_ItemData[i].Hue);
                            bin.Write(m_ItemData[i].StackingOffset); //unk4
                            bin.Write(m_ItemData[i].Value); //unk5
                            bin.Write(m_ItemData[i].Height);
                            byte[] b = new byte[20];
                            if (m_ItemData[i].Name != null)
                            {
                                byte[] bb = Encoding.GetEncoding(1251).GetBytes(m_ItemData[i].Name);
                                if (bb.Length > 20)
                                    Array.Resize(ref bb, 20);
                                bb.CopyTo(b, 0);
                            }
                            bin.Write(b);
                        }
                }
            }
        }

        /// <summary>
        /// Exports <see cref="ItemData"/> to csv file
        /// </summary>
        /// <param name="FileName"></param>
        public static void ExportItemDataToCSV(string FileName)
        {
            using (StreamWriter Tex = new StreamWriter(new FileStream(FileName, FileMode.Create, FileAccess.ReadWrite), System.Text.Encoding.Unicode))
            {
                Tex.Write("ID;Name;Weight/Quantity;Layer/Quality;Gump/AnimID;Height;Hue;Class/Quantity;StackingOffset;MiscData;Unknown2;Unknown3");
                Tex.Write(";Background;Weapon;Transparent;Translucent;Wall;Damage;Impassible;Wet;Unknow1");
                Tex.Write(";Surface;Bridge;Generic;Window;NoShoot;PrefixA;PrefixAn;Internal;Foliage;PartialHue");
                Tex.Write(";Unknow2;Map;Container/Height;Wearable;Lightsource;Animation;HoverOver");
                Tex.WriteLine(";Unknow3;Armor;Roof;Door;StairBack;StairRight");

                for (int i = 0; i < m_ItemData.Length; ++i)
                {
                    ItemData tile = m_ItemData[i];
                    Tex.Write(String.Format("0x{0:X4}", i));
                    Tex.Write(String.Format(";{0}", tile.Name));
                    Tex.Write(";" + tile.Weight);
                    Tex.Write(";" + tile.Quality);
                    Tex.Write(String.Format(";0x{0:X4}", tile.Animation));
                    Tex.Write(";" + tile.Height);
                    Tex.Write(";" + tile.Hue);
                    Tex.Write(";" + tile.Quantity);
                    Tex.Write(";" + tile.StackingOffset);
                    Tex.Write(";" + tile.MiscData);
                    Tex.Write(";" + tile.Unk2);
                    Tex.Write(";" + tile.Unk3);

                    Tex.Write(";" + (((tile.Flags & TileFlag.Background) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Weapon) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Transparent) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Translucent) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Wall) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Damaging) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Impassable) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Wet) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Unknown1) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Surface) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Bridge) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Generic) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Window) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.NoShoot) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.ArticleA) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.ArticleAn) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Internal) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Foliage) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.PartialHue) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Unknown2) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Map) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Container) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Wearable) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.LightSource) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Animation) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.HoverOver) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Unknown3) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Armor) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Roof) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Door) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.StairBack) != 0) ? "1" : "0"));
                    Tex.WriteLine(";" + (((tile.Flags & TileFlag.StairRight) != 0) ? "1" : "0"));
                }
            }
        }

        /// <summary>
        /// Exports <see cref="LandData"/> to csv file
        /// </summary>
        /// <param name="FileName"></param>
        public static void ExportLandDataToCSV(string FileName)
        {
            using (StreamWriter Tex = new StreamWriter(new FileStream(FileName, FileMode.Create, FileAccess.ReadWrite)))
            {
                Tex.Write("ID;Name;TextureID");
                Tex.Write(";Background;Weapon;Transparent;Translucent;Wall;Damage;Impassible;Wet;Unknow1");
                Tex.Write(";Surface;Bridge;Generic;Window;NoShoot;PrefixA;PrefixAn;Internal;Foliage;PartialHue");
                Tex.Write(";Unknow2;Map;Container/Height;Wearable;Lightsource;Animation;HoverOver");
                Tex.WriteLine(";Unknow3;Armor;Roof;Door;StairBack;StairRight");

                for (int i = 0; i < m_LandData.Length; ++i)
                {
                    LandData tile = m_LandData[i];
                    Tex.Write(String.Format("0x{0:X4}", i));
                    Tex.Write(";" + tile.Name);
                    Tex.Write(";" + String.Format("0x{0:X4}", tile.TextureID));

                    Tex.Write(";" + (((tile.Flags & TileFlag.Background) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Weapon) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Transparent) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Translucent) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Wall) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Damaging) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Impassable) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Wet) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Unknown1) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Surface) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Bridge) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Generic) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Window) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.NoShoot) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.ArticleA) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.ArticleAn) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Internal) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Foliage) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.PartialHue) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Unknown2) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Map) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Container) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Wearable) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.LightSource) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Animation) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.HoverOver) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Unknown3) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Armor) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Roof) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.Door) != 0) ? "1" : "0"));
                    Tex.Write(";" + (((tile.Flags & TileFlag.StairBack) != 0) ? "1" : "0"));
                    Tex.WriteLine(";" + (((tile.Flags & TileFlag.StairRight) != 0) ? "1" : "0"));
                }
            }
        }

        public static int ConvertStringToInt(string text)
        {
            int result;
            if (text.Contains("0x"))
            {
                string convert = text.Replace("0x", "");
                int.TryParse(convert, System.Globalization.NumberStyles.HexNumber, null, out result);
            }
            else
                int.TryParse(text, System.Globalization.NumberStyles.Integer, null, out result);

            return result;
        }

        public static void ImportItemDataFromCSV(string FileName)
        {
            if (!File.Exists(FileName))
                return;
            using (StreamReader sr = new StreamReader(FileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if ((line = line.Trim()).Length == 0 || line.StartsWith("#"))
                        continue;
                    if (line.StartsWith("ID;"))
                        continue;
                    try
                    {
                        string[] split = line.Split(';');
                        if (split.Length < 44)
                            continue;

                        int id = ConvertStringToInt(split[0]);
                        m_ItemData[id].ReadData(split);
                    }
                    catch { }

                }
            }
        }

        public static void ImportLandDataFromCSV(string FileName)
        {
            if (!File.Exists(FileName))
                return;
            using (StreamReader sr = new StreamReader(FileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if ((line = line.Trim()).Length == 0 || line.StartsWith("#"))
                        continue;
                    if (line.StartsWith("ID;"))
                        continue;
                    try
                    {
                        string[] split = line.Split(';');
                        if (split.Length < 35)
                            continue;

                        int id = ConvertStringToInt(split[0]);
                        m_LandData[id].ReadData(split);
                    }
                    catch { }
                }
            }
        }
    }

    [StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 1)]
    public unsafe struct LandTileOldDataMul
    {
        public int flags;
        public short texID;
        public fixed byte name[20];
    }

    [StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 1)]
    public unsafe struct LandTileDataMul
    {
        public long flags;
        public short texID;
        public fixed byte name[20];
    }

    [StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ItemTileOldDataMul
    {
        public int flags;
        public byte weight;
        public byte quality;
        public short miscdata;
        public byte unk2;
        public byte quantity;
        public short anim;
        public byte unk3;
        public byte hue;
        public byte stackingoffset;
        public byte value;
        public byte height;
        public fixed byte name[20];
    }

    [StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ItemTileDataMul
    {
        public long flags;
        public byte weight;
        public byte quality;
        public short miscdata;
        public byte unk2;
        public byte quantity;
        public short anim;
        public byte unk3;
        public byte hue;
        public byte stackingoffset;
        public byte value;
        public byte height;
        public fixed byte name[20];
    }

}