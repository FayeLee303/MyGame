using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

//这个类用来绑定
public class Demo_MVCSContext : MVCSContext {
    //构造函数，给父类传一个view对象，就是context要绑定的物体
    public Demo_MVCSContext(MonoBehaviour view):base(view) { }
    
    //进行绑定映射，这里的绑定都是全局的，都要用全局的派发器
    protected override void mapBindings()
    {
        //Model
        //接口和自身做绑定，用自身构造
        injectionBinder.Bind<RoleModel>().To<RoleModel>().ToSingleton();
        //Command
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();//开始命令
        commandBinder.Bind(ViewEvent.TestDug).To<TestCommand>();

        //把View和Mediator绑定，绑定之后Mediator的创建交给StrangeIoc
        mediationBinder.Bind<PlayerView>().To<PlayerMediator>();
        mediationBinder.Bind<TestView>().To<TestMediator>();
        //Service

        //Manager
    }
}
