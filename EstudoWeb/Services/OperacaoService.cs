﻿using System;

namespace EstudoWeb.Services
{
    public class OperacaoService
    {
        public OperacaoService(
            IOperacaoTransient transient,
            IOperacaoScoped scoped,
            IOperacaoSingleton singleton,
            IOperacaoSingletonInstance singletonInstance)
        {
            Transient = transient;
            Scoped = scoped;
            Singleton = singleton;
            SingletonInstance = singletonInstance;
        }

        public IOperacaoTransient Transient { get; }

        public IOperacaoScoped Scoped { get; }

        public IOperacaoSingleton Singleton { get; }

        public IOperacaoSingletonInstance SingletonInstance { get; }
    }

    public class Operacao : IOperacaoTransient, IOperacaoScoped, IOperacaoSingleton, IOperacaoSingletonInstance
    {
        public Guid OperacaoId { get; }

        public Operacao() : this(Guid.NewGuid())
        { }

        public Operacao(Guid guid)
        {
            OperacaoId = guid;
        }
    }

    public interface IOperacao
    {
        Guid OperacaoId { get; }
    }

    public interface IOperacaoTransient : IOperacao
    { }

    public interface IOperacaoScoped : IOperacao
    { }

    public interface IOperacaoSingleton : IOperacao
    { }

    public interface IOperacaoSingletonInstance : IOperacao
    { }


}



