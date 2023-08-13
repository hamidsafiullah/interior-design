export class ProductModel {
    id: number;
    name: string;
    description: string;
    price: number;
    quantity: number;
    isDeleted: boolean;
    deletedAt: Date | null;

    constructor() {
        this.id = 0;
        this.name = '';
        this.description = '';
        this.price = 0;
        this.quantity = 0;
        this.isDeleted = false;
        this.deletedAt = null;
    }
}
