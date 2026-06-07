import sys

filepath = r'Lyhyka\Reports\ElectricBicycleReport.rdlc'
fields = [
    'BrakeSumResult', 'BrakeFrontResult', 'BrakeRearResult',
    'HBResult', 'LBResult', 'AxleTorqueFork',
    'HBDeviationLRLeft', 'HBDeviationLRRight', 'HBDeviationUDUp', 'HBDeviationUDDown',
    'LBDeviationLRLeft', 'LBDeviationLRRight', 'LBDeviationUDUp', 'LBDeviationUDDown',
    'BrakeSumStandard', 'VoltageDropStandard', 'OverCurrentStandard',
    'AxleTorqueFrontStandard', 'AxleTorqueRearStandard', 'AxleTorqueForkStandard',
    'VoltageDropResult', 'OverCurrentResult',
    'AxleTorqueFrontResult', 'AxleTorqueRearResult', 'AxleTorqueForkResult',
    'HideInspectionSection'
]

with open(filepath, 'r', encoding='utf-8') as f:
    for i, line in enumerate(f, 1):
        for fld in fields:
            if fld in line:
                print(f"{i}: [{fld}] {line.strip()[:120]}")
                break
