﻿using System;
using System.Xml;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class FontMan_MLink : Manager
    {
        public Font_DLink poActive;
        public Font_DLink poReserve;
    }
    public class FontMan : FontMan_MLink
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public FontMan(int reserveNum = 3, int reserveGrow = 1)
            : base()
        {
            this.baseInitialize(reserveNum, reserveGrow);
            this.pRefNode = (Font)this.derivedCreateNode();
        }
        ~FontMan()
        {

        }

        //----------------------------------------------------------------------
        // Static Manager methods can be implemented with base methods 
        // Can implement/specialize more or less methods your choice
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(pInstance == null);

            // Do the initialization
            if (pInstance == null)
            {
                pInstance = new FontMan(reserveNum, reserveGrow);
            }
        }
        public static void Destroy()
        {

        }
        public static Font Add(Font.Name name, SpriteBatch.Name SpriteBatch_Name, String pMessage, Glyph.Name glyphName, float xStart, float yStart)
        {
            FontMan pMan = FontMan.privGetInstance();

            Font pNode = (Font)pMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(name, pMessage, glyphName, xStart, yStart);

            // Add to sprite batch
            SpriteBatch pSpriteBatch = SpriteBatchMan.Find(SpriteBatch_Name);
            Debug.Assert(pSpriteBatch != null);
            Debug.Assert(pNode.pFontSprite != null);
            pSpriteBatch.Attach(pNode.pFontSprite);

            return pNode;
        }

        public static void AddXml(Glyph.Name glyphName, String assetName,Texture.Name textName)
        {
            GlyphMan.AddXml(glyphName, assetName, textName);
        }

        public static void Remove(Glyph pNode)
        {
            Debug.Assert(pNode != null);
            FontMan pMan = FontMan.privGetInstance();
            pMan.baseRemove(pNode);
        }
        public static Font Find(Font.Name name)
        {
            FontMan pMan = FontMan.privGetInstance();

            // Compare functions only compares two Nodes
            pMan.pRefNode.name = name;

            Font pData = (Font)pMan.baseFind(pMan.pRefNode);
            return pData;
        }


        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected Boolean derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            // This is used in baseFind() 
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            Font pDataA = (Font)pLinkA;
            Font pDataB = (Font)pLinkB;

            Boolean status = false;

            if (pDataA.name == pDataB.name )
            {
                status = true;
            }

            return status;
        }
        override protected DLink derivedCreateNode()
        {
            DLink pNode = new Font();
            Debug.Assert(pNode != null);
            return pNode;
        }
        override protected void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Font pNode = (Font)pLink;
            pNode.Wash();
        }


        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static FontMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        public static void SetActive(FontMan pFontMan)
        {
            FontMan.pInstance = pFontMan;
        }

        public static FontMan GetActive()
        {
            return FontMan.pInstance;
        }

        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private static FontMan pInstance = null;
        private Font pRefNode;
    }
}
