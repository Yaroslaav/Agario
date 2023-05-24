﻿using SFML.System;
using SFML.Graphics;
    public static class GameObjectFabrik
    {
        public static T CreateActor<T>(this Game game, Shape shape, IntRect rect, Texture texture, Vector2f position = new Vector2f()) where T:GameObject,new()
        {
            T t = CreateActor_Internal<T>(shape, rect, texture, position);
            if (t == null)
                return null;

            RegisterActor(game, t);
            return t;
        }

        private static void RegisterActor(Game game, GameObject t)
        {
            if (t is IUpdatable)
                game.RegisterActor(t as IUpdatable);
            if (t is IDrawable)
                game.RegisterDrawableActor(t);
        }

        private static T CreateActor_Internal<T>(Shape shape, IntRect rect, Texture texture, Vector2f position) where T : GameObject, new()
        {
            GameObjArgs args;
            args.Position = position;
            args.Rect = rect;
            args.Shape = shape;
            args.texture = texture;
            T t = new T();
            t.PostCreate(args);
            return t;
        }
    }
