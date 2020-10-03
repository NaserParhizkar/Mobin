export declare module global {
    interface window {
        blazorKendoWindow(componentId: Element, options: kendo.ui.WindowOptions): kendo.ui.Window;
    }
}

export class tosanWindow implements global.window {
    blazorKendoWindow(componentId: Element, options: kendo.ui.WindowOptions) {
        let win: kendo.ui.Window = new kendo.ui.Window(componentId, options);
        return win;
    }
}

//let tosanWin: tosanWindow = new tosanWindow();
//let element: Element = new Element();
//element.id = 
//tosanWin.blazorKendoWindow()
