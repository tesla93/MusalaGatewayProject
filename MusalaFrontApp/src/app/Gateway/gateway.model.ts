import { PeripheralDevice } from "../peripheral-device/peripheralDevice.model";



export class Gateway{
  public serialNumber: string;
  public name: string;
  public ipAddress: string;
  public peripheralDevices: PeripheralDevice[]

  // constructor(serialNumber: string, name: string, ipAddress: string){
  //   this.serialNumber = serialNumber;
  //   this.ipAddress=ipAddress;
  //   this.name = name;
  // }
}
