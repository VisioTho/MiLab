using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredLitmusDragRestrictor : MonoBehaviour
{
    public GameObject[] beakerDemarcators;
    public GameObject litmusPaper;
    string[] solution_names = { "hydrochloric_acid", "ethanoic_acid", "sodium_hydroxide", "ammonium_solution" };
   
    void Update()
    {
        Vector2 currentLitmusPaperPosition = litmusPaper.transform.position;
      if (litmus_paper_controller.lastDippedInto == solution_names[0])
        {
            litmusPaper.transform.position = new Vector2((beakerDemarcators[0].transform.position.x + beakerDemarcators[1].transform.position.x) / 2, currentLitmusPaperPosition.y);
        }
        if (litmus_paper_controller.lastDippedInto == solution_names[1])
        {
            litmusPaper.transform.position = new Vector2((beakerDemarcators[1].transform.position.x + beakerDemarcators[2].transform.position.x) / 2, currentLitmusPaperPosition.y);
        }
        if (litmus_paper_controller.lastDippedInto == solution_names[2])
        {
            litmusPaper.transform.position = new Vector2((beakerDemarcators[2].transform.position.x + beakerDemarcators[3].transform.position.x) / 2, currentLitmusPaperPosition.y);
        }
        if (litmus_paper_controller.lastDippedInto == solution_names[3])
        {
            litmusPaper.transform.position = new Vector2((beakerDemarcators[3].transform.position.x + beakerDemarcators[4].transform.position.x) / 2, currentLitmusPaperPosition.y);
        }
    }
}
