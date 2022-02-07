export const getRoundedEra = (era: number): number => {
const roundedEra = Math.round((era + Number.EPSILON) * 100) / 100
return roundedEra
}