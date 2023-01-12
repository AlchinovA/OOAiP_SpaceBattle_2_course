using Hwdtech;
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Moq;
using System.Diagnostics;
using SpaceBattle.Lib;
using MySpaceShip.Numeric;

namespace MySpaceShipTests.NumericTests
{
    public class ExpectionThrowerTest
    {
        [Fact]
        public void ExpectionHandlerSuccessful()
        {
            new Hwdtech.Ioc.InitScopeBasedIoCImplementationCommand().Execute();

            IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();


            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Get.Exception.Source", (object[] args) =>
            {
                Exception expection = (Exception)args[0];
                var exp = (new StackTrace(expection).GetFrame(0)!.GetMethod()!.ReflectedType)!.FullName;
                return exp;
            }).Execute();

            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "ExceptionHandler.Command.Priority", (object[] args) =>
            {
                CommandPriorityStrategy comm1 = new();
                return comm1.Run(args);                
            }).Execute();

            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "ExceptionHandler.Exception.Priority", (object[] args) =>
            {
                ExpPriorityStrategy comm1 = new();
                return comm1.Run(args);
            }).Execute();


            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Handler.Tree.Command.Priority", (object[] args) =>
            {
                TreeCommandPriority tree_creater = new();
                return tree_creater.Get_tree(args);
            }).Execute();

            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Handler.Tree.Exception.Priority", (object[] args) =>
            {
                TreeExpPriority tree_creater = new();
                return tree_creater.Get_tree(args);
            }).Execute();


            try
            {
                ExceptionThrower thr = new();
                thr.ExceptionHandling();
            }
            catch (Exception exp)
            {
                IoC.Resolve<SpaceBattle.Lib.ICommand>("ExceptionHandler.Command.Priority", exp, IoC.Resolve<string>("Get.Exception.Source", exp)).Execute();
            }

        }

        [Fact]
        public void ExHandlerNotFound()
        {
            new Hwdtech.Ioc.InitScopeBasedIoCImplementationCommand().Execute();

            IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();


            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Get.Exception.Source", (object[] args) =>
            {
                Exception expection = (Exception)args[0];
                var exp = (new StackTrace(expection).GetFrame(0)!.GetMethod()!.ReflectedType)!.FullName;
                return exp;
            }).Execute();

            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "ExceptionHandler.Command.Priority", (object[] args) =>
            {
                CommandPriorityStrategy comm1 = new();
                return comm1.Run(args);
            }).Execute();

            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "ExceptionHandler.Exception.Priority", (object[] args) =>
            {
                ExpPriorityStrategy comm1 = new();
                return comm1.Run(args);
            }).Execute();


            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Handler.Tree.Command.Priority", (object[] args) =>
            {
                TreeCommandPriority tree_creater = new();
                return tree_creater.Get_tree(args);

            }).Execute();

            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Handler.Tree.Exception.Priority", (object[] args) =>
            {
                TreeExpPriority tree_creater = new();
                return tree_creater.Get_tree(args);
            }).Execute();


            try
            {
                Mock<SpaceBattle.Lib.ICommand> cmd = new();

                cmd.Setup(c => c.Execute()).Throws<Exception>();
            }
            catch (Exception exp)
            {
                Hwdtech.IoC.Resolve<object>("ExceptionHandler.Exception.Priority", exp, IoC.Resolve<string>("Get.Exception.Source", exp));
            }
        }
    }
}