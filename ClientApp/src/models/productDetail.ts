export class ProductDetailModel {
    id: number;
    productId: number;
    detail: string;
    isDeleted: boolean;
    deletedAt: Date | null;

    constructor() {
        this.id = 0;
        this.productId = 0;
        this.detail = '';
        this.isDeleted = false;
        this.deletedAt = null;
    }
}
