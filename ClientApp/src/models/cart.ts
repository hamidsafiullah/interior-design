export class CartModel {
    id: number;
    userId: number;
    items: CartItemModel[];

    constructor() {
        this.id = 0;
        this.userId = 0;
        this.items = [];
    }
}

export class CartItemModel {
    cartId: number;
    productId: number;
    quantity: number;

    constructor() {
        this.cartId = 0;
        this.productId = 0;
        this.quantity = 0;
    }
}
