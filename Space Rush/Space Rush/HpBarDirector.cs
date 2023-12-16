using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public class HpBarDirector
    {
        private HpBarBuilder builder;

        public HpBarDirector(HpBarBuilder builder)
        {
            this.builder = builder;
        }

        public HpBar BuildHpBar(Alive owner)
        {
            this.builder.reset();

            this.builder.SetSize(new Vector2d(owner.GetSize().x, 3));
            this.builder.SetOwner(owner);

            return this.builder.GetProduct();
        }
    }
}
