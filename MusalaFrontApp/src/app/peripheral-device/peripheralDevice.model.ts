export class PeripheralDevice{
  public id: number;
  public vendor: string;
  public dateCreated: Date;
  public status: boolean;
  public gatewayId: string;

  constructor(vendor: string, dateCreated: Date, status: boolean, gatewayId: string){
       this.vendor = vendor;
    this.dateCreated = dateCreated;
    this.status = status;
    this.gatewayId = gatewayId;
  }
}
